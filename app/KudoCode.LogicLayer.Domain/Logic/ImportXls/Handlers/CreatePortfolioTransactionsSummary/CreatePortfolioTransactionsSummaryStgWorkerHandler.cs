using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Entities;
using KudoCode.LogicLayer.Dtos.ImportExcel;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Inbound;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreatePortfolioTransactionsSummary
{
	public class CreatePortfolioTransactionsSummaryStgWorkerHandler
        : QueryHandler<CreateImportXlsDto, ImportXlsDocument, ImportXlsPipelineResponse>
    {
        private readonly ISecondaryExecutionPipeline _executionPipeline;

        private readonly List<Action<List<ImportXlsSheetDetail>, SavePortfolioTransactionsSummaryRequest, ImportXlsSheet>>
            _actions;

        public CreatePortfolioTransactionsSummaryStgWorkerHandler(
            IMapper mapper,
            IReadOnlyRepository repository,
            ILifetimeScope scope,
            ISecondaryExecutionPipeline executionPipeline,
            IWorkerContext<ImportXlsPipelineResponse> context)
            : base(mapper, repository, scope, context)
        {
            _executionPipeline = executionPipeline;
            _actions =
                new List<Action<List<ImportXlsSheetDetail>, SavePortfolioTransactionsSummaryRequest, ImportXlsSheet>>()
                {
                    //GetClosingBalance,
                    //GetOpeningBalance,
                    InterestReceived,
                    TrusteeFees,
                    OtherCharges
                };
        }

        protected override void GetEntity()
        {
            Entity = Repository.GetOne<ImportXlsDocument>(a => a.Id == Context.Result.ImportXlsId);
        }

        protected override void Execute()
        {
            try
            {
                var sheet = Entity.Sheets.Single(a => a.Name.ToLower().Equals("report"));
                var summaryDto = new SavePortfolioTransactionsSummaryRequest {PortfolioId = Context.Result.PortfolioId};

                //Find transaction section
                var transactions =
                    sheet.Details.Where(detail => detail.Value.ToLower().Equals("transactions")).ToList()[1];
                var leftTopCell = sheet.Details.Where(detail =>
                        detail.Row > transactions.Row && detail.Value.ToLower().Equals("Closing balance at".ToLower()))
                    .ToList()[0];

                var leftBottomCell = sheet.Details.Where(detail => detail.Value.ToLower().Equals("ledger")).ToList()[0];

                var startRow = leftTopCell.Row;
                var endRow = leftBottomCell.Row;

                //Find details
                for (var i = startRow; i <= endRow; i++)
                    foreach (var action in _actions)
                        action(sheet.Details.Where(a => a.Row == i).ToList(), summaryDto, sheet);

                GetClosingBalanceDetail(sheet, summaryDto);
                GetOpeningBalanceDetail(sheet, summaryDto);

                var response = _executionPipeline.Execute<SavePortfolioTransactionsSummaryRequest, int>(summaryDto);

                Context.Result.PortfolioTransactionsSummaryId = response.Result;
                Context.Messages.AddRange(response.Messages);
            }
            catch (Exception e)
            {
                Context.AddMessage("E6",
                    $"{this.GetType().Name} unable to process portfolio transactions for staging import Id: {Entity.Id} Name :{Entity.Name}{Environment.NewLine}{e.Message}");
                throw;
            }
        }

        private static void GetOpeningBalanceDetail(ImportXlsSheet sheet,
            SavePortfolioTransactionsSummaryRequest summaryRequest)
        {
            var list = sheet.Details.Where(a => a.Value.ToLower().Contains("Opening balance".ToLower()))
                .OrderBy(a => a.Row).ToList();

            var row = sheet.Details.OrderBy(a => a.Row).Where(a => a.Row == list.Last().Row);

            foreach (var importXlsSheetDetail in row)
            {
                if (GetDate(summaryRequest, importXlsSheetDetail) != null)
                    summaryRequest.OpenDate = GetDate(summaryRequest, importXlsSheetDetail);

                if (GetDouble(summaryRequest, importXlsSheetDetail) != null &&
                    GetDouble(summaryRequest, importXlsSheetDetail) != 0)
                    summaryRequest.OpenAmount = (decimal) GetDouble(summaryRequest, importXlsSheetDetail);
            }
        }


        private static void GetClosingBalanceDetail(ImportXlsSheet sheet,
            SavePortfolioTransactionsSummaryRequest summaryRequest)
        {
            var list = sheet.Details.Where(a => a.Value.ToLower().Contains("Closing balance at".ToLower()))
                .OrderBy(a => a.Row).ToList();

            var items = list.TakeLast(2).ToList();

            var rowClose = sheet.Details.Where(a => a.Row == items[1].Row);

            foreach (var importXlsSheetDetail in rowClose)
            {
                if (GetDate(summaryRequest, importXlsSheetDetail) != null)
                    summaryRequest.CloseDate = GetDate(summaryRequest, importXlsSheetDetail);

                if (GetDouble(summaryRequest, importXlsSheetDetail) != null
                    && GetDouble(summaryRequest, importXlsSheetDetail) != 0)
                    summaryRequest.CloseAmount = (decimal) GetDouble(summaryRequest, importXlsSheetDetail);
            }
        }

        private static void InterestReceived(List<ImportXlsSheetDetail> row, SavePortfolioTransactionsSummaryRequest result,
            ImportXlsSheet sheet)
        {
            if (!row[0].Value.Trim().ToLower().Contains("Interest received".ToLower())) return;

            foreach (var importXlsSheetDetail in row)
            {
                if (importXlsSheetDetail.Value == "0" || !importXlsSheetDetail.Value.IsNumeric()) continue;
                result.InterestReceived = decimal.Parse(importXlsSheetDetail.Value, CultureInfo.InvariantCulture);
                break;
            }
        }

        private static void TrusteeFees(List<ImportXlsSheetDetail> row, SavePortfolioTransactionsSummaryRequest result,
            ImportXlsSheet sheet)
        {
            if (!row[0].Value.Trim().ToLower().Contains("Trustee fees".ToLower())) return;

            foreach (var importXlsSheetDetail in row)
            {
                if (importXlsSheetDetail.Value == "0" || !importXlsSheetDetail.Value.IsNumeric()) continue;
                result.TrusteeFees = decimal.Parse(importXlsSheetDetail.Value, CultureInfo.InvariantCulture);
                break;
            }
        }

        private static void OtherCharges(List<ImportXlsSheetDetail> row, SavePortfolioTransactionsSummaryRequest result,
            ImportXlsSheet sheet)
        {
            if (!row[0].Value.Trim().ToLower().Contains("other charges".ToLower())) return;

            foreach (var importXlsSheetDetail in row)
            {
                if (importXlsSheetDetail.Value == "0" || !importXlsSheetDetail.Value.IsNumeric()) continue;
                result.OtherCharges = decimal.Parse(importXlsSheetDetail.Value, CultureInfo.InvariantCulture);
                break;
            }
        }

        private static decimal? GetDouble(SavePortfolioTransactionsSummaryRequest summaryRequest,
            ImportXlsSheetDetail importXlsSheetDetail)
        {
            if (importXlsSheetDetail.Value != "0" && importXlsSheetDetail.Value.IsNumeric())
                return decimal.Parse(importXlsSheetDetail.Value, CultureInfo.InvariantCulture);
            return null;
        }

        private static string GetDate(SavePortfolioTransactionsSummaryRequest summaryRequest,
            ImportXlsSheetDetail importXlsSheetDetail)
        {
            if (importXlsSheetDetail.Value.Contains("00:00"))
                return importXlsSheetDetail.Value;
            return null;
        }
    }
}
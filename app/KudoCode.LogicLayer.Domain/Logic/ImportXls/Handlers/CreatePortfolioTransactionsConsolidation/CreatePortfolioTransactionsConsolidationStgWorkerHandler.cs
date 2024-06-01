using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Entities;
using KudoCode.LogicLayer.Dtos.ImportExcel;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Inbound;
using log4net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
//using Microsoft.EntityFrameworkCore.Scaffolding.Internal;

namespace KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreatePortfolioTransactionsConsolidation
{
	public class CreatePortfolioTransactionsConsolidationStgWorkerHandler
        : QueryHandler<CreateImportXlsDto, ImportXlsDocument, ImportXlsPipelineResponse>
    {
        private readonly ILog _logger;
        private readonly ISecondaryExecutionPipeline _secondaryExecutionPipeline;
        private ImportXlsSheet _sheet;

        public CreatePortfolioTransactionsConsolidationStgWorkerHandler(
            IMapper mapper,
            IReadOnlyRepository repository,
            ILifetimeScope scope,
            ILog logger,
            ISecondaryExecutionPipeline secondaryExecutionPipeline,
            IWorkerContext<ImportXlsPipelineResponse> context)
            : base(mapper, repository, scope, context)
        {
            _logger = logger;
            _secondaryExecutionPipeline = secondaryExecutionPipeline;
        }

        protected override void GetEntity()
        {
            Entity = Repository.GetOne<ImportXlsDocument>(a => a.Id == Context.Result.ImportXlsId,
                src => src.Include(a => a.Sheets).ThenInclude(a => a.Details));
        }

        protected override void ValidateEntity()
        {
            _sheet = Entity.Sheets?.SingleOrDefault(a => a.Name.ToLower().Equals("report"))
                     ?? Entity.Sheets?[0];

            if (_sheet != null) return;

            Context.AddMessage("E6", $"{GetType().Name} sheet Report not found {Request.FilePath}");
        }

        protected override void Execute()
        {
            IEnumerable<IGrouping<int, ImportXlsSheetDetail>> consolidationGroups;
            try
            {
                var rowStartGroups = _sheet.Details.Where(
                    a =>
                        a.Value.ToLower().Equals("Stratum".ToLower())
                        || a.Value.ToLower().Equals("Sector".ToLower())
                        || a.Value.ToLower().Equals("Cluster".ToLower())
                        || a.Value.ToLower().Equals("Code".ToLower())
                ).GroupBy(a => a.Row);

                var rowStartId = rowStartGroups.OrderBy(a => a.Key).First(a => a.Count() == 4).Key;

                var rowEndId = _sheet.Details.Where(
                    a =>
                        a.Value.ToLower().Equals("Cash on".ToLower())
                        || a.Value.ToLower().Equals("Equity".ToLower())
                        || a.Value.ToLower().Equals("Dividends".ToLower())
                ).GroupBy(a => a.Row).Single(a => a.Count() == 3).Key;

                consolidationGroups = _sheet.Details
                    .OrderBy(a => a.Row)
                    .Where(a => a.Row > rowStartId && a.Row < rowEndId)
                    .GroupBy(a => a.Row);
            }
            catch (Exception e)
            {
                Context.AddMessage("E6",
                    $"{this.GetType().Name} unable to locate portfolio transactions consolidation for staging import Id: {Entity.Id} Name :{Entity.Name}{Environment.NewLine}{e.Message}");
                throw;
            }

            var dtos = new List<SavePortfolioTransactionsConsolidationDto>();

            foreach (var group in consolidationGroups)
            {
                try
                {
                    var row = group.ToList().OrderBy(a => a.Column).ToList();

                    if (string.IsNullOrWhiteSpace(row[0].Value))
                        continue;

                    dtos.Add(new SavePortfolioTransactionsConsolidationDto()
                    {
                        Id = 0,
                        PortfolioTransactionsSummaryId = Context.Result.PortfolioTransactionsSummaryId,
                        ShortName = row[0].Value,
                        Code = row[1].Value,
                        Stratum = row[2].Value,
                        Sector = row[3].Value,
                        Cluster = row[4].Value,
                        ClosingNo = GetInt(row[5].Value),
                        ClosingPrice = GetDecimal(row[6].Value),
                        ClosingValue = GetDecimal(row[7].Value),
                        MyProp = GetDecimal(row[8].Value),
                        Dividends = GetDecimal(row[9].Value),
                        Rung = GetInt(row[10].Value),
                        PeriodGain = GetDecimal(row[11].Value),
                        PeriodReturn = GetDecimal(row[12].Value),
                        ReturnOnWai = GetDecimal(row[13].Value),
                        ShareProfilePe = GetDecimal(row[14].Value),
                        ShareProfileDy = GetDecimal(row[15].Value),
                        ShareProfileDp = GetDecimal(row[16].Value),
                        AnnualisedEarnings = GetDecimal(row[17].Value),
                        AnnualisedDividends = GetDecimal(row[18].Value),
                        OpeningNo = GetInt(row[19].Value),
                        OpeningPrice = GetDecimal(row[20].Value),
                        OpeningValue = GetDecimal(row[21].Value),
                    });
                }
                catch (Exception e)
                {
                    Context.AddMessage("W6",
                        $"{this.GetType().Name} unable to CAST portfolio transactions consolidation row for staging import Id: {Entity.Id} Name :{Entity.Name}{Environment.NewLine}{e.Message}");
                }
            }

            foreach (var savePortfolioTransactionsConsolidationDto in dtos)
            {
                var saveResponse = ApplicationContext
                    .Container
                    .Resolve<IHandler<SavePortfolioTransactionsConsolidationDto, IWorkerContext<int>>>()
                    .Handle(savePortfolioTransactionsConsolidationDto);

                Context.Messages.AddRange(saveResponse.Messages);
            }

            //Context.Result.PortfolioTransactionsSummaryId;
            //Context.Result.PortfolioId = response.Result;
            //Context.Messages.AddRange(response.Messages);
        }

        private static decimal GetDecimal(string value)
        {
            return string.IsNullOrWhiteSpace(value)
                ? 0.0m
                : decimal.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        private static int GetInt(string value)
        {
            return string.IsNullOrWhiteSpace(value)
                ? 0
                : int.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
        }
    }
}
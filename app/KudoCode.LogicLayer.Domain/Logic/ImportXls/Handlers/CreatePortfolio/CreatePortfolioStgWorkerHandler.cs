using System.Linq;
using Autofac;
using AutoMapper;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Entities;
using KudoCode.LogicLayer.Dtos.ImportExcel;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using log4net;

namespace KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreatePortfolio
{
    public class CreatePortfolioStgWorkerHandler
        : QueryHandler<CreateImportXlsDto, ImportXlsDocument, ImportXlsPipelineResponse>
    {
        private readonly ILog _logger;
        private readonly ISecondaryExecutionPipeline _secondaryExecutionPipeline;
        private ImportXlsSheet _sheet;

        public CreatePortfolioStgWorkerHandler(
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
                "Sheets,Sheets.Details");
        }

        protected override void ValidateEntity()
        {
            _sheet = Entity.Sheets?.SingleOrDefault(a => a.Name.ToLower().Equals("report"))
                     ?? Entity.Sheets?[0];

            if (_sheet != null) return;

            Context.AddMessage("E6", $"{this.GetType().Name} sheet Report not found {Request.FilePath}");
        }

        protected override void Execute()
        {
            var row = _sheet.Details.Where(a => a.Row == 0).ToList();

            var portfolioName = _sheet.Details.First(a => a.Row == 0).Value;
            foreach (var importXlsSheetDetail in row)
                if (!string.IsNullOrEmpty(importXlsSheetDetail.Value)
                    && !importXlsSheetDetail.Value.IsNumeric()
                    && !importXlsSheetDetail.Value.Contains("00:00"))
                    portfolioName = importXlsSheetDetail.Value;

            var response = _secondaryExecutionPipeline.Execute<SavePortfolioRequest, int>(new SavePortfolioRequest()
            {
                Id = 0,
                Name = portfolioName.Trim()
            });
            _logger.Debug(
                $"{this.GetType().Name} Portfolio saved {portfolioName}=={response.Result}  - {Request.FilePath}");

            Context.Result.PortfolioId = response.Result;
            Context.Messages.AddRange(response.Messages);
        }
    }
}
using KudoCode.LogicLayer.Domain.Logic.Portfolios.Entities;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.ImportExcel;
using KudoCode.LogicLayer.Infrastructure.Execution.Interfaces;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Handlers.CreateImportXls
{
    public class CreatePortfolioImportXlsDtoWorkerHandler : WorkerHandler<CreateImportXlsDto, int>
    {
        public CreatePortfolioImportXlsDtoWorkerHandler(
            IMapper mapper,
            ILifetimeScope scope,
            IWorkerContext<int> context)
            : base(mapper, scope, context)
        {
        }


        protected override void Execute()
        {
            var response = Scope.ResolveKeyed<IExecutionPipelineHandlers>("ImportProfile")
                .Execute<CreateImportXlsDto, ImportXlsPipelineResponse>(Request);

            Context.Messages.AddRange(response.Messages);

            if (response.Result != null)
                Context.Result = response.Result.PortfolioId;
        }
    }
}
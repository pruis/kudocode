using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.ImportExcel;

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
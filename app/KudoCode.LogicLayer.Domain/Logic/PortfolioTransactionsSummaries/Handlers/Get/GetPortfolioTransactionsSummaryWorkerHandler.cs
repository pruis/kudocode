using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Entities;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Handlers.Get
{
    public class GetPortfolioTransactionsSummaryRequestWorkerHandler : QueryHandler<
        GetPortfolioTransactionsSummaryRequest,
        PortfolioTransactionsSummary, GetPortfolioTransactionsSummaryResponse>
    {
        public GetPortfolioTransactionsSummaryRequestWorkerHandler(
            IMapper mapper,
            IReadOnlyRepository repository,
            ILifetimeScope scope,
            IWorkerContext<GetPortfolioTransactionsSummaryResponse> context)
            : base(mapper, repository, scope, context)
        {
        }

        protected override void GetEntity()
        {
            Entity = Repository.GetOne<PortfolioTransactionsSummary>(a => a.Id == Request.SummaryId);
        }

        protected override void ValidateEntity()
        {
            if (Entity == null)
                Context.AddMessage("E4", $"Portfolio Transactions Summary not found with ID {Request.SummaryId}");
        }

        protected override void Execute()
        {
            Context.Result = Mapper.Map<GetPortfolioTransactionsSummaryResponse>(Entity);
        }
    }
}
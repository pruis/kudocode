using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.Portfolios.Entities;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Handlers.GetPortfolio
{
    public class GetPortfolioWorkerHandler : QueryHandler<GetPortfolioRequest,
        Portfolio, GetPortfolioResponse>
    {
        public GetPortfolioWorkerHandler(
            IMapper mapper,
            IReadOnlyRepository repository,
            ILifetimeScope scope,
            IWorkerContext<GetPortfolioResponse> context)
            : base(mapper, repository, scope, context)
        {
        }

        protected override void GetEntity()
        {
            Entity = Request.Id > 0
                ? Repository.GetOne<Portfolio>(a => a.Id == Request.Id,
                    "Accounts," +
                    "TransactionsSummaries," +
                    "Transactions," +
                    "Transactions.PortfolioTransactionType," +
                    "Transactions.PortfolioShare")
                : new Portfolio();
        }

        protected override void ValidateEntity()
        {
            if (Entity == null)
                Context.AddMessage("E4", $"Portfolio with id {Request.Id}");
        }

        protected override void Execute()
        {
            Context.Result = Mapper.Map<GetPortfolioResponse>(Entity);
        }
    }
}
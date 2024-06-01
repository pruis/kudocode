using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactions.Entities;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactions.Handlers.Get
{
	public class GetPortfolioTransactionRequestWorkerHandler : QueryHandler<GetPortfolioTransactionRequest,
        PortfolioTransaction, GetPortfolioTransactionResponse>
    {
        public GetPortfolioTransactionRequestWorkerHandler(
            IMapper mapper,
            IReadOnlyRepository repository,
            ILifetimeScope scope,
            IWorkerContext<GetPortfolioTransactionResponse> context)
            : base(mapper, repository, scope, context)
        {
        }

        protected override void GetEntity()
        {
            Entity = Repository.GetOne<PortfolioTransaction>(a =>
                a.Id == Request.Id && a.PortfolioId == Request.PortfolioId);
        }

        protected override void ValidateEntity()
        {
            if (Entity == null)
                Context.AddMessage("E4",
                    $"Portfolio Transaction with ID {Request.Id} and Portfolio Id {Request.PortfolioId}");
        }

        protected override void Execute()
        {
            Context.Result = Mapper.Map<GetPortfolioTransactionResponse>(Entity);
        }
    }
}
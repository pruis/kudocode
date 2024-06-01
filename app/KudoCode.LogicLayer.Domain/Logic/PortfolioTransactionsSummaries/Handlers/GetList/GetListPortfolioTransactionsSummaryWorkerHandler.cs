using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Entities;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Handlers.GetList
{
	public class GetListPortfolioTransactionsSummaryWorkerHandler : QueryHandler<
        GetListPortfolioTransactionsSummaryRequest,
        List<PortfolioTransactionsSummary>, GetListPortfolioTransactionsSummaryResponse>
    {
        public GetListPortfolioTransactionsSummaryWorkerHandler(
            IMapper mapper,
            IReadOnlyRepository repository,
            ILifetimeScope scope,
            IWorkerContext<GetListPortfolioTransactionsSummaryResponse> context)
            : base(mapper, repository, scope, context)
        {
        }

        protected override void GetEntity()
        {
            Entity = Repository.Get<PortfolioTransactionsSummary>(a => a.PortfolioId
                                                                       == Request.PortfolioId).ToList();
        }

        protected override void Execute()
        {
            Context.Result = new GetListPortfolioTransactionsSummaryResponse()
            {
                PortfolioTransactionsSummaries = Mapper.Map<List<GetPortfolioTransactionsSummaryResponse>>(Entity)
            };
        }
    }
}
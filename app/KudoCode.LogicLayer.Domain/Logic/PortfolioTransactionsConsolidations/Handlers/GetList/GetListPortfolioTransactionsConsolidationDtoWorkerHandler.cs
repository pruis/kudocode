using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsConsolidations.Entities;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Outbound;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsConsolidations.Handlers.GetList
{
    public class GetListPortfolioTransactionsConsolidationDtoWorkerHandler : QueryHandler<
        GetListPortfolioTransactionsConsolidationDto,
        List<PortfolioTransactionsConsolidation>, List<PortfolioTransactionsConsolidationDto>>
    {
        public GetListPortfolioTransactionsConsolidationDtoWorkerHandler(
            IMapper mapper,
            IReadOnlyRepository repository,
            ILifetimeScope scope,
            IWorkerContext<List<PortfolioTransactionsConsolidationDto>> context)
            : base(mapper, repository, scope, context)
        {
        }

        protected override void GetEntity()
        {
            var x = Repository.Get<PortfolioTransactionsConsolidation>();

            Entity = Repository.Get<PortfolioTransactionsConsolidation>(a =>
                a.PortfolioTransactionsSummaryId == Request.PortfolioTransactionsSummaryId).ToList();
        }

        protected override void ValidateEntity()
        {
        }

        protected override void Execute()
        {
            Context.Result = Mapper.Map<List<PortfolioTransactionsConsolidationDto>>(Entity);
        }
    }
}
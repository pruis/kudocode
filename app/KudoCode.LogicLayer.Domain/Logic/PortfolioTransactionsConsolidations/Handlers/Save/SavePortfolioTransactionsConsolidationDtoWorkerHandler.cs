using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsConsolidations.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Entities;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Inbound;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsConsolidations.Handlers.Save
{
	public class SavePortfolioTransactionsConsolidationDtoWorkerHandler : CommandHandler<
        SavePortfolioTransactionsConsolidationDto,
        PortfolioTransactionsConsolidation, int>
    {
        public SavePortfolioTransactionsConsolidationDtoWorkerHandler(
            IMapper mapper,
            IRepository repository,
            ILifetimeScope scope,
            IWorkerContext<int> context)
            : base(mapper, repository, scope, context)
        {
        }

        protected override void GetEntity()
        {
            Entity = Request.Id > 0
                ? Repository.GetOne<PortfolioTransactionsConsolidation>(a => a.Id == Request.Id)
                : new PortfolioTransactionsConsolidation();

            if (Request.Id == 0)
                Entity.PortfolioTransactionsSummary =
                    Repository.GetOne<PortfolioTransactionsSummary>(a => a.Id == Request.PortfolioTransactionsSummaryId);
        }

        protected override void ValidateEntity()
        {
            if (Entity == null)
                Context.AddMessage("E4", $"PortfolioTransactionsConsolidation with ID: {Request.Id}");
        }

        protected override void Execute()
        {
            Mapper.Map(Request, Entity);
            Repository.Save(Entity);
            Repository.SaveChanges();
            Context.Result = Entity.Id;
        }
    }
}
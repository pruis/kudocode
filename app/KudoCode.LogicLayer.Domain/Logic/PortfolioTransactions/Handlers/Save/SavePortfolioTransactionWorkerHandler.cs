using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactions.Entities;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Inbound;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactions.Handlers.Save
{
	public class SavePortfolioTransactionWorkerHandler : CommandHandler<SavePortfolioTransactionRequest,
        PortfolioTransaction, int>
    {
        public SavePortfolioTransactionWorkerHandler(
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
                ? Repository.GetOne<PortfolioTransaction>(a => a.Id == Request.Id)
                : new PortfolioTransaction();
        }

        protected override void ValidateEntity()
        {
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
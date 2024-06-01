using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.Portfolios.Entities;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Handlers.SavePortfolio
{
	public class SavePortfolioWorkerHandler : CommandHandler<SavePortfolioRequest, Portfolio, int>
    {
        public SavePortfolioWorkerHandler(
            IMapper mapper,
            IRepository repository,
            ILifetimeScope scope,
            IWorkerContext<int> context) : base(mapper, repository, scope, context)
        {
        }

        protected override void GetEntity()
        {
            Entity = Request.Id > 0
                ? Repository.GetOne<Portfolio>(a => a.Id == Request.Id)
                : Repository.GetOne<Portfolio>(a => a.Name.ToLower().Equals(Request.Name.Trim().ToLower()));

            if (Entity == null && Request.Id == 0)
                Entity = new Portfolio();
        }

        protected override void ValidateEntity()
        {
            if (Entity == null)
                Context.AddMessage("E4");
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
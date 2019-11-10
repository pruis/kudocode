using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.Update
{
    public class UpdateLeadWorkerHandler : CommandHandler<UpdateLeadRequest, Lead, int>
    {
        public UpdateLeadWorkerHandler(
            IMapper mapper,
            IRepository repository,
            ILifetimeScope scope,
            IWorkerContext<int> context)
            : base(mapper, repository, scope, context)
        {
        }

        protected override void GetEntity()
        {
            Entity = Repository.GetOne<Lead>(a => a.Id == Request.Id,
                "LeadPersonalInformation");
        }

        protected override void Execute()
        {
            Mapper.Map(Request, Entity);
            Repository.Save(Entity).SaveChanges();
            Context.Result = Entity.Id;
        }
    }
}
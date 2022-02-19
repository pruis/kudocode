using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Dtos.Leads;
using Microsoft.EntityFrameworkCore;

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
                src => src .Include(a => a.LeadPersonalInformation));
        }

        protected override void Execute()
        {
            Mapper.Map(Request, Entity);
            Repository.Save(Entity).SaveChanges();
            Context.Result = Entity.Id;
        }
    }
}
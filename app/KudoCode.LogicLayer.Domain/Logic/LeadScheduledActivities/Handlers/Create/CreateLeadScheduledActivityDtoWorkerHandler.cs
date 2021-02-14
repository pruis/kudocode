using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.LeadScheduledActivities.Create
{
    public class
        CreateLeadScheduledActivityDtoWorkerHandler : CommandHandler<CreateGetLeadScheduledActivityRequest,
            LeadScheduledActivity, int>
    {
        protected override void Execute()
        {
            Entity = Mapper.Map<LeadScheduledActivity>(Request);
            Repository.Save(Entity);
            Repository.SaveChanges();
            Context.Result = Entity.Id;
        }

        public CreateLeadScheduledActivityDtoWorkerHandler(IMapper mapper, IRepository repository, ILifetimeScope scope,
            IWorkerContext<int> context) : base(mapper, repository, scope, context)
        {
        }
    }
}
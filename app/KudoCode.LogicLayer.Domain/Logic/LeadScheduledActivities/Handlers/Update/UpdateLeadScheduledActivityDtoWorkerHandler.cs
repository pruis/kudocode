using System.Collections.Generic;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.Get;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;

namespace KudoCode.LogicLayer.Domain.Logic.LeadScheduledActivities.Update
{
    public class
        UpdateLeadScheduledActivityDtoWorkerHandler : CommandHandler<UpdateGetLeadScheduledActivityRequest,
            LeadScheduledActivity, int>, IRedisCacheCommandHandler
    {
        protected override void GetEntity()
        {
            Entity = Repository.GetOne<LeadScheduledActivity>(a => a.Id == Request.Id, "Address");
        }

        protected override void Execute()
        {
            Mapper.Map(Request, Entity);
            Repository.Save(Entity);
            Repository.SaveChanges();
            Context.Result = Entity.Id;
        }

        public UpdateLeadScheduledActivityDtoWorkerHandler(IMapper mapper, IRepository repository, ILifetimeScope scope,
            IWorkerContext<int> context) : base(mapper, repository, scope, context)
        {
        }

        public List<string> RedisKeys()
        {
            return new List<string>()
                {$"{typeof(GetLeadWorkerHandler).Name}_{typeof(Lead).Name}_{Entity?.LeadId.ToString()}"};
        }
    }
}
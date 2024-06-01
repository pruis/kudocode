using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.Get;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace KudoCode.LogicLayer.Domain.Logic.LeadScheduledActivities.Update
{
	public class
        UpdateLeadScheduledActivityDtoWorkerHandler : CommandHandler<UpdateGetLeadScheduledActivityRequest,
            LeadScheduledActivity, int>, IRedisCacheCommandHandler
    {
        protected override void GetEntity()
        {
            Entity = Repository.GetOne<LeadScheduledActivity>(a => a.Id == Request.Id, src => src .Include(a => a.Address));
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
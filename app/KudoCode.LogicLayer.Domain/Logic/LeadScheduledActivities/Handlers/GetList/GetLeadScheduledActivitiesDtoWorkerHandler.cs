using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.LeadScheduledActivities.GetList
{
    public class GetLeadScheduledActivitiesDtoWorkerHandler :
        QueryHandler<GetListLeadScheduledActivityRequest, List<LeadScheduledActivity>, List<GetLeadScheduledActivityResponse>>
    {
        protected override void GetEntity()
        {
            var q = Repository.GetIQueryable<LeadScheduledActivity>(null, "Address");
            q = q.Where(a => a.LeadId == Request.LeadId);
            Entity = q.ToList();
        }

        protected override void Execute()
        {
            Context.Result = Mapper.Map<List<GetLeadScheduledActivityResponse>>(Entity);
        }

        protected override void ValidateEntity()
        {
            if (Entity == null)
                Context.AddMessage("E4");
        }

        public GetLeadScheduledActivitiesDtoWorkerHandler(IMapper mapper, IReadOnlyRepository repository,
            IComponentContext scope, IWorkerContext<List<GetLeadScheduledActivityResponse>> context)
            : base(mapper, repository, scope, context)
        {
        }
    }
}
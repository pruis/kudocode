using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.LeadScheduledActivities.Get
{
    public class GetLeadScheduledActivityWorkerHandler : QueryHandler<GetLeadScheduledActivityRequest,
        LeadScheduledActivity
        , GetLeadScheduledActivityResponse>
    {
        protected override void GetEntity()
        {
            Entity = Repository.GetOne<LeadScheduledActivity>(a => a.Id == Request.Id && a.LeadId == Request.LeadId,
                "Address");
        }

        protected override void Execute()
        {
            Context.Result = Mapper.Map<GetLeadScheduledActivityResponse>(Entity);
        }

        protected override void ValidateEntity()
        {
            if (Entity == null)
                Context.AddMessage("E4");
        }

        public GetLeadScheduledActivityWorkerHandler(
            IMapper mapper,
            IReadOnlyRepository repository,
            IComponentContext scope,
            IWorkerContext<GetLeadScheduledActivityResponse> context) : base(mapper, repository, scope,
            context)
        {
        }
    }
}
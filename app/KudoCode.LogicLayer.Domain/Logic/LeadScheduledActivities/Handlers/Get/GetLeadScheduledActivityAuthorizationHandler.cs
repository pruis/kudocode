using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.LeadScheduledActivities.Get
{
    public class GetLeadScheduledActivityAuthorizationHandler : AbstractAuthorizationHandler<
        GetLeadScheduledActivityRequest, GetLeadScheduledActivityResponse>
    {
        public GetLeadScheduledActivityAuthorizationHandler(IApplicationUserContext applicationUserContext
            , IAuthorizationContext<GetLeadScheduledActivityResponse> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.Contracts;

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
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.LeadScheduledActivities.Create
{
	public class
        CreateLeadScheduledActivityDtoAuthorizationHandler : AbstractAuthorizationHandler<
            CreateGetLeadScheduledActivityRequest, int>
    {
        public CreateLeadScheduledActivityDtoAuthorizationHandler(IApplicationUserContext applicationUserContext
            , IAuthorizationContext<int> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
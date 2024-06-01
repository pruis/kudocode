using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.LeadScheduledActivities.Update
{
	public class UpdateLeadScheduledActivityDtoAuthorizationHandler : AbstractAuthorizationHandler<UpdateGetLeadScheduledActivityRequest, int>
	{
		public UpdateLeadScheduledActivityDtoAuthorizationHandler(IApplicationUserContext applicationUserContext
			, IAuthorizationContext<int> context)
			: base(applicationUserContext, context)
		{
			IsLoggedIn();
		}
	}
}
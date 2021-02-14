using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

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
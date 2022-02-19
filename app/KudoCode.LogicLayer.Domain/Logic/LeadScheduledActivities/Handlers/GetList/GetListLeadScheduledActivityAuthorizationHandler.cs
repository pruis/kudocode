using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.Contracts;
using System.Collections.Generic;

namespace KudoCode.LogicLayer.Domain.Logic.LeadScheduledActivities.GetList
{
	public class GetListLeadScheduledActivityAuthorizationHandler : AbstractAuthorizationHandler<
        GetListLeadScheduledActivityRequest, List<GetLeadScheduledActivityResponse>>
    {
        public GetListLeadScheduledActivityAuthorizationHandler(IApplicationUserContext applicationUserContext
            , IAuthorizationContext<List<GetLeadScheduledActivityResponse>> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
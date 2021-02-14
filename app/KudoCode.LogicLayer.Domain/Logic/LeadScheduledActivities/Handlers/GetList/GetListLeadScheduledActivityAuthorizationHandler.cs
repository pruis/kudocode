using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

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
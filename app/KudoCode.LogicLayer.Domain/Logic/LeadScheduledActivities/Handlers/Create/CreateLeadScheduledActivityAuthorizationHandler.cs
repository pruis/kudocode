using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

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
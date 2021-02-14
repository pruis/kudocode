using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.Update
{
    public class UpdateLeadAuthorizationHandler : AbstractAuthorizationHandler<UpdateLeadRequest, int>
    {
        public UpdateLeadAuthorizationHandler(IApplicationUserContext applicationUserContext
            , IAuthorizationContext<int> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
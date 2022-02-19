using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.Contracts;

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
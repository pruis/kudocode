using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.Create
{
	public class CreateLeadAuthorizationHandler : AbstractAuthorizationHandler<CreateLeadRequest, int>
    {
        public CreateLeadAuthorizationHandler(IApplicationUserContext applicationUserContext
            , IAuthorizationContext<int> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
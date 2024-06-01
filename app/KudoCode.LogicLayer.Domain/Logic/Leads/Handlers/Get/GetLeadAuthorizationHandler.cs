using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.Get
{
	public class GetLeadAuthorizationHandler : AbstractAuthorizationHandler<GetLeadRequest, GetLeadResponse>
    {
        public GetLeadAuthorizationHandler(IApplicationUserContext applicationUserContext
            , IAuthorizationContext<GetLeadResponse> context)
            : base(applicationUserContext, context)
        {
            //IsLoggedIn();
            AllowAnonymous = true;
        }

    }
}
using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.Lookup.Handlers.GetLookups
{
	public class GetLookupsDtoAuthorizationHandler : AbstractAuthorizationHandler<GetLookupRequest, GetLookupResponse>
    {
        public GetLookupsDtoAuthorizationHandler(IApplicationUserContext applicationUserContext
            , IAuthorizationContext<GetLookupResponse> context)
            : base(applicationUserContext, context)
        {
            AllowAnonymous = true;
        }
    }
}
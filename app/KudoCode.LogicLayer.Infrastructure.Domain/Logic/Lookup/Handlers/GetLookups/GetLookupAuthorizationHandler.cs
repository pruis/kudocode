using KudoCode.LogicLayer.Dtos.Lookups;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

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
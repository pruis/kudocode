using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class
        GetApplicationUserDtoAuthorizationHandler : AbstractAuthorizationHandler<GetApplicationUserRequest,
            GetApplicationUserResponse>
    {
        public GetApplicationUserDtoAuthorizationHandler(IApplicationUserContext applicationUserContext,
            IAuthorizationContext<GetApplicationUserResponse> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
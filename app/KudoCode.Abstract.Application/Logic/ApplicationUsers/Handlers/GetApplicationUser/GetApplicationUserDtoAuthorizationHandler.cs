using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class
        GetApplicationUserDtoAuthorizationHandler : AbstractAuthorizationHandler<GetApplicationUserDto,
            ApplicationUserDto>
    {
        public GetApplicationUserDtoAuthorizationHandler(IApplicationUserContext applicationUserContext,
            IAuthorizationContext<ApplicationUserDto> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
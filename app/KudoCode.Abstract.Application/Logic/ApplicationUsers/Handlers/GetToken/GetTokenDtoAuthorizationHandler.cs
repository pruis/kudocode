using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class GetTokenDtoAuthorizationHandler : AbstractAuthorizationHandler<GetTokenRequest, ApplicationUserContext>
	{

		public GetTokenDtoAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<ApplicationUserContext> context) 
			: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}

using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{

	public class LoadTableConfigAuthorizationHandler : AbstractAuthorizationHandler<LoadTableConfigRequest, LoadTableConfigResponse>
	{

		public LoadTableConfigAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<LoadTableConfigResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


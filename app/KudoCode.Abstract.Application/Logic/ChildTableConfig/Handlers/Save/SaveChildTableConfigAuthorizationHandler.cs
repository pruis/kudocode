using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{

	public class SaveChildTableConfigAuthorizationHandler : AbstractAuthorizationHandler<SaveChildTableConfigRequest, SaveChildTableConfigResponse>
	{

		public SaveChildTableConfigAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<SaveChildTableConfigResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


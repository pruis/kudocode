using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{

	public class SavePropertyConfigAuthorizationHandler : AbstractAuthorizationHandler<SavePropertyConfigRequest, SavePropertyConfigResponse>
	{

		public SavePropertyConfigAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<SavePropertyConfigResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


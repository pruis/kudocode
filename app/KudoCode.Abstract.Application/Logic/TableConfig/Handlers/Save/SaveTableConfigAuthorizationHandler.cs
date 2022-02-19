using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{

	public class SaveTableConfigAuthorizationHandler : AbstractAuthorizationHandler<SaveTableConfigRequest, SaveTableConfigResponse>
	{

		public SaveTableConfigAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<SaveTableConfigResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{

	public class SaveDynamicAuthorizationHandler : AbstractAuthorizationHandler<SaveDynamicRequest, SaveDynamicResponse>
	{

		public SaveDynamicAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<SaveDynamicResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


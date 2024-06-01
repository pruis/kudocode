using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{

	public class GetPropertyConfigAuthorizationHandler : AbstractAuthorizationHandler<GetPropertyConfigRequest, GetPropertyConfigResponse>
	{

		public GetPropertyConfigAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<GetPropertyConfigResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


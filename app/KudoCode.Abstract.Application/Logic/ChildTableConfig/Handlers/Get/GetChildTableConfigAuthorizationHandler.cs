using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{

	public class GetChildTableConfigAuthorizationHandler : AbstractAuthorizationHandler<GetChildTableConfigRequest, GetChildTableConfigResponse>
	{

		public GetChildTableConfigAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<GetChildTableConfigResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


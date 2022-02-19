using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{

	public class GetTableConfigAuthorizationHandler : AbstractAuthorizationHandler<GetTableConfigRequest, GetTableConfigResponse>
	{

		public GetTableConfigAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<GetTableConfigResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


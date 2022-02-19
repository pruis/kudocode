using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{

	public class GetDynamicAuthorizationHandler : AbstractAuthorizationHandler<GetDynamicRequest, GetDynamicResponse>
	{

		public GetDynamicAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<GetDynamicResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


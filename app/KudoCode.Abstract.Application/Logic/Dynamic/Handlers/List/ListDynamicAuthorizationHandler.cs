using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{

	public class ListDynamicAuthorizationHandler : AbstractAuthorizationHandler<ListDynamicRequest, ListDynamicResponse>
	{

		public ListDynamicAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<ListDynamicResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


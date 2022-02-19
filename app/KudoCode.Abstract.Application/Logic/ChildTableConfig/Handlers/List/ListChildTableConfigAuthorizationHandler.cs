using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{

	public class ListChildTableConfigAuthorizationHandler : AbstractAuthorizationHandler<ListChildTableConfigRequest, ListChildTableConfigResponse>
	{

		public ListChildTableConfigAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<ListChildTableConfigResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


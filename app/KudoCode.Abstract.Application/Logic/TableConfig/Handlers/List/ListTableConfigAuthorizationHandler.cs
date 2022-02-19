using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{

	public class ListTableConfigAuthorizationHandler : AbstractAuthorizationHandler<ListTableConfigRequest, ListTableConfigResponse>
	{

		public ListTableConfigAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<ListTableConfigResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


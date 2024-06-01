using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{

	public class ListPropertyConfigAuthorizationHandler : AbstractAuthorizationHandler<ListPropertyConfigRequest, ListPropertyConfigResponse>
	{

		public ListPropertyConfigAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<ListPropertyConfigResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


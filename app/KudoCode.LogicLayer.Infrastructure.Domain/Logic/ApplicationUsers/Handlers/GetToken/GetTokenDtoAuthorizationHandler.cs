using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Handlers.GetToken
{
	public class GetTokenDtoAuthorizationHandler : AbstractAuthorizationHandler<GetTokenRequest, ApplicationUserContext>
	{

		public GetTokenDtoAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<ApplicationUserContext> context) 
			: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}

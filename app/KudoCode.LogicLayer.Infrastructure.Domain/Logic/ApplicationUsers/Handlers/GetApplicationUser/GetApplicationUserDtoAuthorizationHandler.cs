using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Handlers.GetApplicationUser
{
    public class
        GetApplicationUserDtoAuthorizationHandler : AbstractAuthorizationHandler<GetApplicationUserDto,
            ApplicationUserDto>
    {
        public GetApplicationUserDtoAuthorizationHandler(IApplicationUserContext applicationUserContext,
            IAuthorizationContext<ApplicationUserDto> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
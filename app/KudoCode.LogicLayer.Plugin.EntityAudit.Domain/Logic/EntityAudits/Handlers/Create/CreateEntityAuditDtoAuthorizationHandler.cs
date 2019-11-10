using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using KudoCode.LogicLayer.Plugin.EntityAudit.Dtos.Interfaces;

namespace KudoCode.LogicLayer.Plugin.EntityAudit.Domain.Logic.EntityAudits.Handlers.Create
{
    public class CreateEntityAuditDtoAuthorizationHandler : AbstractAuthorizationHandler<ICreateEntityAuditDto, int>
    {
        public CreateEntityAuditDtoAuthorizationHandler(
            IApplicationUserContext applicationUserContext,
            IAuthorizationContext<int> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
            AllowAnonymous = false;
        }
    }
}
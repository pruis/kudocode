using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos.Interfaces;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Handlers.Create
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
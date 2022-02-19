using System.Data;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos.Interfaces;
using FluentValidation;
using KudoCode.Contracts.Api;
using KudoCode.Contracts.Api;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Handlers.Create
{
    public class CreateEntityAuditDtoValidationHandler : AbstractValidator<ICreateEntityAuditDto>
    {
        public CreateEntityAuditDtoValidationHandler()
        {
            RuleFor(s => s.Entity).NotEmpty();
            RuleFor(s => s.CreatedBy).NotEmpty();
            RuleFor(s => s.EntityId).NotEqual(0);
            RuleFor(s => s.CreatedDate).IsValidDate();
        }
    }
}
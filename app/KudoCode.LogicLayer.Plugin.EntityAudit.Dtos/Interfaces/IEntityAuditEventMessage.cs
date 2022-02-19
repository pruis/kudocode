using System.Collections.Generic;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos.Interfaces
{
    public interface IEntityAuditEventMessage
    {
        List<PropertyInformationDto> PropertyInformation { get; set; }
        string Entity { get; set; }
        int EntityId { get; set; }
    }
}
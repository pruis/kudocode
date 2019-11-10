using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Plugin.EntityAudit.Dtos.Interfaces
{
    public interface ICreateEntityAuditDto : IApiRequestDto
    {
        int ApplicationUserId { get; set; }
        string Entity { get; set; }
        int EntityId { get; set; }
        List<PropertyInformationDto> PropertyInformation { get; set; }
        string CreatedBy { get; set; }
        string CreatedDate { get; set; }
    }
}
using KudoCode.Contracts;
using System.Collections.Generic;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos.Interfaces
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
using KudoCode.Contracts;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos.Interfaces;
using System.Collections.Generic;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos
{
	public class CreateEntityAuditDto : IApiRequestDto, ICreateEntityAuditDto
    {
        public List<PropertyInformationDto> PropertyInformation { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string Entity { get; set; }
        public int EntityId { get; set; }
        public int ApplicationUserId { get; set; }
    }
}
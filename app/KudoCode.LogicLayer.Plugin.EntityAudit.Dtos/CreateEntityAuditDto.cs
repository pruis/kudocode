using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;
using KudoCode.LogicLayer.Plugin.EntityAudit.Dtos.Interfaces;

namespace KudoCode.LogicLayer.Plugin.EntityAudit.Dtos
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
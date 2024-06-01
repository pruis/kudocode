using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Entities.Interface;
using System;
using System.Collections.Generic;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Entities
{
	public class EntityAudit : IEntity, IEntityAudit
    {
        public EntityAudit()
        {
            PropertyInformation = new List<PropertyInformation>();
        }

        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public string Entity { get; set; }
        public int EntityId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<PropertyInformation> PropertyInformation { get; set; }
    }

    public class PropertyInformation : IEntity, IPropertyInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int EntityAuditId { get; set; }
    }
}
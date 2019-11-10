using System;
using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Plugin.EntityAudit.Domain.Logic.EntityAudits.Entities.Interface;

namespace KudoCode.LogicLayer.Plugin.EntityAudit.Domain.Logic.EntityAudits.Entities
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
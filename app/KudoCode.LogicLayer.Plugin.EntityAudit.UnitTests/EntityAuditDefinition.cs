using System.Linq;
using KudoCode.LogicLayer.Plugin.EntityAudit.Domain.Logic.EntityAudits.Plugin.Interfaces;
using KudoCode.LogicLayer.Plugin.EntityAudit.UnitTests.Objects;

namespace KudoCode.LogicLayer.Plugin.EntityAudit.UnitTests
{
    public class EntityAuditDefinition : IAuditDefinition<Entity>
    {
        public object GetAudit(Entity entity)
        {
            return new
            {
                entity.Id,
                entity.Name,
                AssociatedEnties = new {Ids = entity.AssociatedEntities?.Select(a => new {Id = a.Id}).ToList()}
            };
        }
    }
}
using System.Linq;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Plugin.Interfaces;
using KudoCode.LogicLayer.Plugin.EntityAudit_.UnitTests.Objects;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.UnitTests
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
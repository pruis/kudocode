using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;

namespace KudoCode.LogicLayer.Plugin.EntityAudit.UnitTests.Objects
{
    public class Entity : IEntity
    {
        public string Name { get; set; }
        public List<AssociatedEntity> AssociatedEntities { get; set; }

        public int Id { get; set; }
    }
}
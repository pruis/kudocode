using KudoCode.Contracts.Api;
using KudoCode.Contracts.Api;
using System.Collections.Generic;


namespace KudoCode.LogicLayer.Plugin.EntityAudit_.UnitTests.Objects
{
    public class Entity : IEntity
    {
        public string Name { get; set; }
        public List<AssociatedEntity> AssociatedEntities { get; set; }

        public int Id { get; set; }
    }
}
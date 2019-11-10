using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioShares.Entities
{
    public class PortfolioShare : IEntity, ILookup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Stratum { get; set; }
        public string Sector { get; set; }
        public string Cluster { get; set; }
    }
}
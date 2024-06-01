using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.Lookups
{
    public class PortfolioShareDto : ILookupDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.PortfolioAccounts.OutBound
{
    public class GetPortfolioAccountRequest : IApiRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PortfolioId { get; set; }
    }
}

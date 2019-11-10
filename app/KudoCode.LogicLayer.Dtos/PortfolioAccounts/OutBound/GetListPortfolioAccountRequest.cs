using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.PortfolioAccounts.OutBound
{
    public class GetListPortfolioAccountRequest : IApiRequestDto
    {
        public int PortfolioId { get; set; }
    }
}
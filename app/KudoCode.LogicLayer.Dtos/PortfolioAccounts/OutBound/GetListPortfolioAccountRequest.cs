using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.PortfolioAccounts.OutBound
{
    public class GetListPortfolioAccountRequest : IApiRequestDto
    {
        public int PortfolioId { get; set; }
    }
}
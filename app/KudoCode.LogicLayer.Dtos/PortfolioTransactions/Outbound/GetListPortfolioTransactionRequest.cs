using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound
{
    public class GetListPortfolioTransactionRequest : IApiRequestDto
    {
        public int PortfolioId { get; set; }
    }
}
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound
{
    public class GetPortfolioTransactionRequest : IApiRequestDto
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
    }
}
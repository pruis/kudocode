using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.PortfolioTransactions.Inbound
{
    public class SavePortfolioTransactionRequest : IApiRequestDto
    {
        public int Id { get; set; }

        public int PortfolioId { get; set; }
        public int PortfolioShareId { get; set; }

        public int PortfolioTransactionTypeId { get; set; }

        public string Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
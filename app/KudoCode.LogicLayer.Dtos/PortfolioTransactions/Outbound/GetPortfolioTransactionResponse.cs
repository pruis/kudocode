namespace KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound
{
    public class GetPortfolioTransactionResponse
    {
        public int Id { get; set; }

        public int PortfolioShareId { get; set; }

        public int PortfolioTransactionTypeId { get; set; }

        public string Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

    }
}
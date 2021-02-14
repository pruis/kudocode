namespace KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound
{
    public class PortfolioTransactionResponse
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public int PortfolioShareId { get; set; }
        public string PortfolioShareDescription { get; set; }
        public string PortfolioTransactionType { get; set; }
        public string Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
namespace KudoCode.Web.Application.Models.PortfolioTransactionsSummary
{
    public class GetPortfolioTransactionsSummaryViewModel
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }

        public decimal CloseAmount { get; set; }
        public decimal OpenAmount { get; set; }
        public string OpenDate { get; set; }
        public string CloseDate { get; set; }
        public decimal InterestReceived { get; set; }
        public decimal TrusteeFees { get; set; }
        public decimal OtherCharges { get; set; }
    }
}
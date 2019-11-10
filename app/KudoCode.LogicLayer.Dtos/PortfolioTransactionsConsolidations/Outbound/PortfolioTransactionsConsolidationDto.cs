using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Outbound
{
    public class PortfolioTransactionsConsolidationDto : IApiRequestDto
    {
        public int Id { get; set; }
        public int PortfolioTransactionsSummaryId { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        public string Stratum { get; set; }
        public string Sector { get; set; }
        public string Cluster { get; set; }
        public int ClosingNo { get; set; }
        public decimal ClosingPrice { get; set; }
        public decimal ClosingValue { get; set; }
        public decimal MyProp { get; set; }
        public decimal Dividends { get; set; }
        public int Rung { get; set; }
        public decimal PeriodGain { get; set; }
        public decimal PeriodReturn { get; set; }
        public decimal ReturnOnWai { get; set; }
        public decimal ShareProfilePe { get; set; }
        public decimal ShareProfileDy { get; set; }
        public decimal ShareProfileDp { get; set; }
        public decimal AnnualisedEarnings { get; set; }
        public decimal AnnualisedDividends { get; set; }
        public int OpeningNo { get; set; }
        public decimal OpeningPrice { get; set; }
        public decimal OpeningValue { get; set; }
    }
}
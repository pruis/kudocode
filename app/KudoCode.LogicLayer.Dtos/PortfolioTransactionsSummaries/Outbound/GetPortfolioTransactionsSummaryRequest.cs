using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound
{
    public class GetPortfolioTransactionsSummaryRequest : IApiRequestDto
    {
        public int SummaryId { get; set; }
    }
}
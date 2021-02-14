using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound
{
    public class GetPortfolioTransactionsSummaryRequest : IApiRequestDto
    {
        public int SummaryId { get; set; }
    }
}
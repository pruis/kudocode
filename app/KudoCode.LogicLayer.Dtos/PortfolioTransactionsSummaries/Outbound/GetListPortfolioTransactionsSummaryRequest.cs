using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound
{
    public class GetListPortfolioTransactionsSummaryRequest : IApiRequestDto
    {
        public int PortfolioId { get; set; }
    }
}
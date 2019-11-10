using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Outbound
{
    public class GetListPortfolioTransactionsConsolidationDto : IApiRequestDto
    {
        public int PortfolioTransactionsSummaryId { get; set; }
    }
}
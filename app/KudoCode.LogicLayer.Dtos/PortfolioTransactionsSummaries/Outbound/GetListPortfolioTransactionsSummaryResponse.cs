using System.Collections.Generic;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound
{
    public class GetListPortfolioTransactionsSummaryResponse : IApiRequestDto
    {
        public List<GetPortfolioTransactionsSummaryResponse> PortfolioTransactionsSummaries { get; set; }
    }
}
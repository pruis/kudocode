using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound
{
    public class GetListPortfolioTransactionsSummaryResponse : IApiRequestDto
    {
        public List<GetPortfolioTransactionsSummaryResponse> PortfolioTransactionsSummaries { get; set; }
    }
}
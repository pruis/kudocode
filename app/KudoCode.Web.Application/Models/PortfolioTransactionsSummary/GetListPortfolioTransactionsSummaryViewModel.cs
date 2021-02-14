using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;

namespace KudoCode.Web.Application.Models.PortfolioTransactionsSummary
{
    public class GetListPortfolioTransactionsSummaryViewModel
    {
        public GetListPortfolioTransactionsSummaryViewModel()
        {
            PortfolioTransactionsSummaries = new List<GetPortfolioTransactionsSummaryResponse>();
        }

        public List<GetPortfolioTransactionsSummaryResponse> PortfolioTransactionsSummaries { get; set; }
    }
}
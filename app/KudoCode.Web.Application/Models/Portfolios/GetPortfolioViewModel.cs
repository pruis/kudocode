using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.Lookups;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;

namespace KudoCode.Web.Application.Models.Portfolios
{
    public class GetPortfolioViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OpenDate { get; set; }

        public List<GetPortfolioTransactionsSummaryResponse> TransactionsSummaries { get; set; }
        public List<PortfolioTransactionResponse> Transactions { get; set; }

    }
}
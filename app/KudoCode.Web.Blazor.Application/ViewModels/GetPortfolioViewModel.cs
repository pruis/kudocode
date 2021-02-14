using System;
using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.PortfolioAccounts.OutBound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;

namespace KudoCode.Web.Blazor.Application.ViewModels
{
    public class GetPortfolioViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime OpenDate { get; set; }

        public List<GetPortfolioTransactionsSummaryResponse> TransactionsSummaries { get; set; }
        public List<PortfolioTransactionResponse> Transactions { get; set; }
        public List<PortfolioAccountResponse> Accounts { get; set; }
    }
}
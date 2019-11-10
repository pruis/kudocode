using System.Collections.Generic;

namespace KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound
{
    public class GetListPortfolioTransactionResponse
    {
        public List<PortfolioTransactionResponse> PortfolioTransactions { get; set; }
    }
}
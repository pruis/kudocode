using System.Collections.Generic;
using KudoCode.Contracts;

namespace KudoCode.Web.Application.Models.PortfolioTransactions
{
    public class GetPortfolioTransactionViewModel
    {
        public int Id { get; set; }

        public int PortfolioId { get; set; }
        public int PortfolioShareId { get; set; }

        public int PortfolioTransactionTypeId { get; set; }

        public string Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public List<LookupResponse> PortfolioTransactionType { get; set; }
        public List<LookupResponse> PortfolioShare { get; set; }
    }
}
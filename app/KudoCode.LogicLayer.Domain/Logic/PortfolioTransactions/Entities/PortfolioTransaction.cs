using KudoCode.LogicLayer.Domain.Logic.Portfolios.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioShares.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsTypes.Entities;
using KudoCode.Contracts.Api;
using System;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactions.Entities
{
	public class PortfolioTransaction : IEntity, IEntityBasicAudit
    {
        public int Id { get; set; }

        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }

        public int PortfolioShareId { get; set; }
        public PortfolioShare PortfolioShare { get; set; }

        public int PortfolioTransactionTypeId { get; set; }
        public PortfolioTransactionType PortfolioTransactionType { get; set; }

        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
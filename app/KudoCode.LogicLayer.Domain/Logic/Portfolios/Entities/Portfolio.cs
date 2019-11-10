using System;
using System.Collections.Generic;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactions.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Entities;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Entities
{
    public class Portfolio : IEntity
    {
        public Portfolio()
        {
            TransactionsSummaries = new List<PortfolioTransactionsSummary>();
            Transactions = new List<PortfolioTransaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime OpenDate { get; set; }

        public List<PortfolioTransactionsSummary> TransactionsSummaries { get; set; }
        public List<PortfolioTransaction> Transactions { get; set; }
        public List<PortfolioAccount> Accounts { get; set; }
    }
}
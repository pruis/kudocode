using System;
using System.Collections.Generic;
using KudoCode.LogicLayer.Domain.Logic.Portfolios.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsConsolidations.Entities;
using KudoCode.Contracts.Api;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Entities
{
    public class PortfolioTransactionsSummary : IEntity
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }

        public List<PortfolioTransactionsConsolidation> PortfolioTransactionsConsolidations { get; set; }

        public decimal CloseAmount { get; set; }
        public decimal OpenAmount { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public decimal InterestReceived { get; set; }
        public decimal TrusteeFees { get; set; }
        public decimal OtherCharges { get; set; }
    }
}
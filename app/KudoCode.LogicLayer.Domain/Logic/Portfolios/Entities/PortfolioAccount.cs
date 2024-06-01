using KudoCode.Contracts.Api;
using System;


namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Entities
{
	public class PortfolioAccount : IEntity, IEntityBasicAudit
    {
        public int Id { get; set; }

        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }

        //public PortfolioAccountType AccountType { get; set; }
        //public int AccountTypeId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public decimal OpenUnits { get; set; }
        public decimal OpenAmount { get; set; }
        public string OpenDate { get; set; }

        public decimal Units { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
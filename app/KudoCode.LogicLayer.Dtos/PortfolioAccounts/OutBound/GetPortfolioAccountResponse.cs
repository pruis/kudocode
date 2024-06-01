using System;
using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.PortfolioAccountTypes.Outbound;

namespace KudoCode.LogicLayer.Dtos.PortfolioAccounts.OutBound
{
    public class GetPortfolioAccountResponse
    {
        public int Id { get; set; }
        //public PortfolioAccountTypeResponse AccountType { get; set; }
        public int AccountTypeId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public decimal OpenUnits { get; set; }
        public decimal OpenAmount { get; set; }
        public string OpenDate { get; set; }

        public decimal Units { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
    }
}
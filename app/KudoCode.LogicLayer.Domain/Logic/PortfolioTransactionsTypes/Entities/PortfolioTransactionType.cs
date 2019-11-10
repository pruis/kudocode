using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsTypes.Entities
{
    public class PortfolioTransactionType :IEntity, ILookup
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
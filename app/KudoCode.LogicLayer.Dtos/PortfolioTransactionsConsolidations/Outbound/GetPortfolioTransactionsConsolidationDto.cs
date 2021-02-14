using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Outbound
{
    public class GetPortfolioTransactionsConsolidationDto : IApiRequestDto
    {
        public int Id { get; set; }
    }
}
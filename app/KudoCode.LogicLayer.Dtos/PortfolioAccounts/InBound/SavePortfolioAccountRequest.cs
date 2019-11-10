using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.PortfolioAccounts.InBound
{
    public class SavePortfolioAccountRequest : IApiRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PortfolioId { get; set; }
        public int AccountTypeId { get; set; }

    }
}

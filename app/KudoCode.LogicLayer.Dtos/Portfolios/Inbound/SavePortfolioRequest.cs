using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.Portfolios.Inbound
{
    public class SavePortfolioRequest : IApiRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OpenDate { get; set; }

    }
}
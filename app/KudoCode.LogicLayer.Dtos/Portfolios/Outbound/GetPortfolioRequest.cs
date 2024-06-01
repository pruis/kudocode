using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.Portfolios.Outbound
{
    public class GetPortfolioRequest : IApiRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.Lookups;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;

namespace KudoCode.Web.Application.Models.Portfolios
{
    public class GetListPortfolioViewModel
    {
        public GetListPortfolioViewModel()
        {
            Portfolios = new List<PortfolioResponse>();
        }

        public List<PortfolioResponse> Portfolios { get; set; }
    }
}
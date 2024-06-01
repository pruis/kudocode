using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;

namespace KudoCode.Web.Blazor.Application.ViewModels
{
    public class GetListPortfolioViewModel
    {
        public List<PortfolioResponse> Portfolios { get; set; }
    }
}
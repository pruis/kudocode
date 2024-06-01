using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Outbound;

namespace KudoCode.Web.Application.Models.PortfolioTransactionsConsolidation
{
    public class GetListPortfolioTransactionsConsolidationViewModel
    {
        public GetListPortfolioTransactionsConsolidationViewModel()
        {
            PortfolioTransactionsConsolidations = new List<GetListPortfolioTransactionsConsolidationDto>();
        }

        public List<GetListPortfolioTransactionsConsolidationDto> PortfolioTransactionsConsolidations { get; set; }
    }
}
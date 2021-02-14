using KudoCode.Web.Infrastructure.Domain.Execution;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.Web.Application.Models.Portfolios;

using KudoCode.Web.Application.Models.PortfolioTransactionsSummary;
using Microsoft.AspNetCore.Mvc;

namespace KudoCode.Web.Application.Controllers
{
    [ServiceFilter(typeof(WebTokenAuthorizationAttribute))]
    public class PortfolioTransactionsSummariesController : Controller
    {
        private readonly WebExecutionPipeline _executionPipeline;

        public PortfolioTransactionsSummariesController(WebExecutionPipeline executionPipeline)
        {
            _executionPipeline = executionPipeline;
        }

        public IActionResult Index(int id)
        {
            var result =
                _executionPipeline
                    .Execute<GetListPortfolioTransactionsSummaryRequest, GetListPortfolioTransactionsSummaryViewModel>(
                        new GetListPortfolioTransactionsSummaryRequest() {PortfolioId = id});
            return View(result);
        }
    }
}
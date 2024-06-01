using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Inbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.Web.Application.Models.Portfolios;

using KudoCode.Web.Application.Models.PortfolioTransactionsSummary;
using Microsoft.AspNetCore.Mvc;
using KudoCode.Contracts.Web;

namespace KudoCode.Web.Application.Controllers
{
    [ServiceFilter(typeof(WebTokenAuthorizationAttribute))]
    public class PortfolioTransactionsSummaryController : Controller
    {
        private readonly WebExecutionPipeline _executionPipeline;

        public PortfolioTransactionsSummaryController(WebExecutionPipeline executionPipeline)
        {
            _executionPipeline = executionPipeline;
        }

        public IActionResult Edit(int id)
        {
            var result =
                _executionPipeline
                    .Execute<GetPortfolioTransactionsSummaryRequest, GetPortfolioTransactionsSummaryViewModel>(
                        new GetPortfolioTransactionsSummaryRequest() {SummaryId = id});
            return View(result);
        }

        [HttpPost]
        public IActionResult Save(SavePortfolioTransactionsSummaryRequest model)
        {
            var result = _executionPipeline.Execute<SavePortfolioTransactionsSummaryRequest, int>(model);
            return Json(result, Helpers.Json.Serialization.Default());
        }
    }
}
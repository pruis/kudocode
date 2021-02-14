using KudoCode.Web.Infrastructure.Domain.Execution;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Outbound;
using KudoCode.Web.Application.Models.Portfolios;

using KudoCode.Web.Application.Models.PortfolioTransactionsConsolidation;
using Microsoft.AspNetCore.Mvc;

namespace KudoCode.Web.Application.Controllers
{
    [ServiceFilter(typeof(WebTokenAuthorizationAttribute))]
    public class PortfolioTransactionsConsolidationsController : Controller
    {
        private readonly WebExecutionPipeline _executionPipeline;

        public PortfolioTransactionsConsolidationsController(WebExecutionPipeline executionPipeline)
        {
            _executionPipeline = executionPipeline;
        }

        public IActionResult Index(int id)
        {
            var result = _executionPipeline.Execute<GetListPortfolioTransactionsConsolidationDto,
                GetListPortfolioTransactionsConsolidationViewModel>(new GetListPortfolioTransactionsConsolidationDto()
                {PortfolioTransactionsSummaryId = id});
            return View(result);
        }

        public IActionResult Edit(int id)
        {
            var result = _executionPipeline.Execute<GetPortfolioTransactionsConsolidationDto,
                SavePortfolioTransactionsConsolidationViewModel>(new GetPortfolioTransactionsConsolidationDto()
                {Id = id});
            return View(result);
        }

        [HttpPost]
        public IActionResult Save(SavePortfolioTransactionsConsolidationViewModel model)
        {
            var result = _executionPipeline.Execute<SavePortfolioTransactionsConsolidationViewModel, int>(model);
            return Json(result);
        }
    }
}
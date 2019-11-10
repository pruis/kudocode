using KudoCode.Web.Infrastructure.Domain.Execution;
using System.Linq;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Inbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;

using KudoCode.Web.Application.Models.PortfolioTransactions;
using Microsoft.AspNetCore.Mvc;

namespace KudoCode.Web.Application.Controllers
{
    [ServiceFilter(typeof(WebTokenAuthorizationAttribute))]
    public class PortfolioTransactionController : Controller
    {
        private readonly WebExecutionPipeline _executionPipeline;

        public PortfolioTransactionController(WebExecutionPipeline executionPipeline)
        {
            _executionPipeline = executionPipeline;
        }

        [HttpGet("[controller]/[action]/{id:int}/{portfolioId:int}")]
        public IActionResult Edit(int id, int portfolioId)
        {
            var result =
                _executionPipeline.Execute<GetPortfolioTransactionRequest, GetPortfolioTransactionViewModel>(
                    new GetPortfolioTransactionRequest() {Id = id, PortfolioId = portfolioId});
            return View(result);
        }

        [HttpPost]
        public IActionResult Save(SavePortfolioTransactionRequest model)
        {
            var result = _executionPipeline.Execute<SavePortfolioTransactionRequest, int>(model);
            if (!result.HasErrors())
                result.Messages.Add(new MessageDto("M1", "Success", 0));
            return Json(result, Helpers.Json.Serialization.Default());
        }
    }
}
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;

using KudoCode.Web.Application.Models.Portfolios;
using KudoCode.Contracts.Web;
using Microsoft.AspNetCore.Mvc;

namespace KudoCode.Web.Application.Controllers
{
    [ServiceFilter(typeof(WebTokenAuthorizationAttribute))]
    public class PortfolioController : Controller
    {
        private readonly WebExecutionPipeline _executionPipeline;

        public PortfolioController(WebExecutionPipeline executionPipeline)
        {
            _executionPipeline = executionPipeline;
        }

        public IActionResult Edit(int id)
        {
            var result =
                _executionPipeline.Execute<GetPortfolioRequest, GetPortfolioViewModel>(new GetPortfolioRequest() {Id = id});
            return View(result);
        }

        [HttpPost]
        public IActionResult Save(SavePortfolioRequest model)
        {
            var result = _executionPipeline.Execute<SavePortfolioRequest, int>(model);
            return Json(result, Helpers.Json.Serialization.Default());
        }
    }
}
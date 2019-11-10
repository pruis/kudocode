using KudoCode.Web.Infrastructure.Domain.Execution;
using System.Collections.Generic;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Dtos.Leads;

using KudoCode.Web.Application.Models.Leads;
using Microsoft.AspNetCore.Mvc;

namespace KudoCode.Web.Application.Controllers.Leads
{
    [ServiceFilter(typeof(WebTokenAuthorizationAttribute))]
    public class LeadsController : Controller
    {
        private readonly WebExecutionPipeline _executionPipeline;

        public LeadsController(WebExecutionPipeline executionPipeline)
        {
            _executionPipeline = executionPipeline;
        }

        public IActionResult Index()
        {
            return View(new WebResponseDto<LeadsViewModel>());
        }

        [HttpPost]
        public IActionResult SearchAction(GetListLeadRequest dto)
        {
            var result = _executionPipeline.Execute<GetListLeadRequest, List<GetLeadResponse>>(dto);
            return Json(result, Helpers.Json.Serialization.Default());
        }
    }
}
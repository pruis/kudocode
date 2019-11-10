using KudoCode.Web.Infrastructure.Domain.Execution;
using System.Linq;
using KudoCode.Web.Application.Models.Leads;

using KudoCode.Web.Application.Models.LeadScheduledActivity;
using Microsoft.AspNetCore.Mvc;

namespace KudoCode.Web.Application.Controllers.Leads
{
    [ServiceFilter(typeof(WebTokenAuthorizationAttribute))]
    public class LeadScheduledActivityController : Controller
    {
        private readonly WebExecutionPipeline _executionPipeline;

        public LeadScheduledActivityController(WebExecutionPipeline executionPipeline)
        {
            _executionPipeline = executionPipeline;
        }

        public IActionResult Edit(int id, int leadId)
        {
            return View(
                _executionPipeline.Execute<Get, LeadScheduledActivityViewModel>(new Get() {Id = id, LeadId = leadId}));
        }

        [HttpPost]
        public IActionResult Save(LeadScheduledActivityViewModel dto)
        {
            var response = _executionPipeline.Execute<LeadScheduledActivityViewModel, int>(dto);
            if (!response.HasErrors())
                response.SetRedirect("Redirect", Url.Action("Edit", "Lead", new {id = dto.LeadId}), "Lead");

            return Json(response, Helpers.Json.Serialization.Default());
        }
    }
}
using KudoCode.Web.Infrastructure.Domain.Execution;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.Web.Application.Models.Leads;

using KudoCode.Web.Application.Models.Lead;
using Microsoft.AspNetCore.Mvc;

namespace KudoCode.Web.Application.Controllers.Leads
{
	[ServiceFilter(typeof(WebTokenAuthorizationAttribute))]
	public class LeadController : Controller
    {
	    private readonly WebExecutionPipeline _executionPipeline;

	    public LeadController(WebExecutionPipeline executionPipeline)
	    {
		    _executionPipeline = executionPipeline;
	    }

	    public IActionResult Index()
        {
			return View();
        }
	    public IActionResult Edit(int id)
	    {
	        var result = _executionPipeline.Execute<GetLeadRequest, LeadViewModel>(new GetLeadRequest() {Id = id});
			return View(result);
        }

		[HttpPost]
		public IActionResult Save(LeadViewModel model)
		{
			var result = _executionPipeline.Execute<LeadViewModel, int>(model);
			return Json(result,Helpers.Json.Serialization.Default());
        }
    }
}
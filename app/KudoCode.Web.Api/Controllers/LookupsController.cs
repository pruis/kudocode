﻿using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.Contracts;
using Microsoft.AspNetCore.Mvc;
namespace KudoCode.Web.Api.Controllers
{
	[Produces("application/json")]
    [Route("api/Lookups")]
	[TokenAuthentication]
	public class LookupsController : Controller
    {
	    private ExecutionPipeline _executionPlan;

	    public LookupsController(ExecutionPipeline executionPlan )
	    {
		    _executionPlan = executionPlan;
	    }

	    [HttpPost]
	    [Route("[action]")]
	    public IApiResponseContextDto<GetLookupResponse> Get([FromBody] GetLookupRequest request)
	    {
		    var result = _executionPlan.Execute<GetLookupRequest, GetLookupResponse>(request);
		    return result;
	    }
	}
}
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KudoCode.Web.Api.Controllers
{
	[Route("api/[controller]")]
	public class AuthenticationController : Controller
	{
		private readonly ExecutionPipeline _executionPlan;

		public AuthenticationController(ExecutionPipeline executionPlan)
		{
			_executionPlan = executionPlan;
		}

		[HttpPost]
		[Route("[action]")]
		public IApiResponseContextDto<ApplicationUserContext> RequestToken([FromBody] GetTokenRequest request)
		{
			var result = _executionPlan.Execute<GetTokenRequest, ApplicationUserContext>(request);
			return result;
		}

		[HttpPost]
		[Route("[action]")]
		public IApiResponseContextDto<ApplicationUserContext> Register([FromBody] SaveApplicationUserRequest model)
		{
			var result = _executionPlan.Execute<SaveApplicationUserRequest, ApplicationUserContext>(model);
			return result;
		}
	}
}
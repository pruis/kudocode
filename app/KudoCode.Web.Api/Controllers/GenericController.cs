using System.Threading.Tasks;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests;
using KudoCode.LogicLayer.Infrastructure.Execution.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace KudoCode.Web.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/Generic")]
	[EnableCors("AllowOrigin")]

	[TokenAuthentication]
	public class GenericController : Controller
	{
		private readonly ApiControllerRequestManager _apiControllerRequestManager;

		public GenericController(ApiControllerRequestManager apiControllerRequestManager)
		{
			_apiControllerRequestManager = apiControllerRequestManager;
		}

		[HttpPost]
		[Route("[action]")]
		public async Task<object> Post([FromBody] ApiControllerRequestDto dto) => await _apiControllerRequestManager.Execute(dto);
	}
}
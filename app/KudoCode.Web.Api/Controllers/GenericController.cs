using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
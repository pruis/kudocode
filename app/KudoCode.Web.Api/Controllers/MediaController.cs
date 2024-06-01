using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace KudoCode.Web.Api.Controllers
{
    [Route("api/Media")]
    [ApiController]
    public class MediaController : ControllerBase
    {

		[HttpPost]
		[Route("Upload")]
		[EnableCors("AllowOrigin")]
		public ActionResult Upload(ICollection<IFormFile> files)
		{
			try
			{
				// Put your code here
				return StatusCode(200);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

	}
}

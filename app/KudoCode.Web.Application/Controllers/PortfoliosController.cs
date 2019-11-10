using System;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Web.Application.Models.Portfolios;
using KudoCode.Web.Infrastructure.Domain.Execution;
using Microsoft.AspNetCore.Mvc;

namespace KudoCode.Web.Application.Controllers
{
	[ServiceFilter(typeof(WebTokenAuthorizationAttribute))]
	public class PortfoliosController : Controller
	{
		private readonly WebExecutionPipeline _executionPipeline;

		public PortfoliosController(WebExecutionPipeline executionPipeline)
		{
			_executionPipeline = executionPipeline;
		}

		public IActionResult Index()
		{
			var result =
				_executionPipeline.Execute<GetListPortfolioRequest, GetListPortfolioViewModel>(
					new GetListPortfolioRequest());
			return View(result);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KudoCode.Web.Application.Controllers
{
	[ServiceFilter(typeof(WebTokenAuthorizationAttribute))]
	public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
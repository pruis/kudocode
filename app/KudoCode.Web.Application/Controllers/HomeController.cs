using System.Diagnostics;
using KudoCode.Contracts;
using KudoCode.Contracts;
using Microsoft.AspNetCore.Mvc;
using KudoCode.Web.Application.Models;

namespace KudoCode.Web.Application.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

	        var response = new ResponseModel<GetTokenRequest>();

	        response.Result = new GetTokenRequest()
	        {
		        Email = "testB@testC.com",
		        Password = "1234",
	        };
			return View(response);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

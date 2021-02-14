using System;
using System.Diagnostics;
using System.Linq;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using KudoCode.Web.Api.Connector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using KudoCode.Web.Application.Models;
using KudoCode.Web.Infrastructure.Domain;
using KudoCode.Web.Infrastructure.Domain.Execution;
using Microsoft.Extensions.Configuration;


namespace KudoCode.Web.Application.Controllers
{
    public class AuthenticationController : Controller
    {
        private Connector _connector;
        private readonly IConfiguration _configuration;
        private readonly IStorage _storage;

        public AuthenticationController(Connector connector, IConfiguration configuration, IStorage storage)
        {
            _connector = connector;
            _configuration = configuration;
            _storage = storage;
        }

        public IActionResult Login()
        {
            var response = new ResponseModel<GetTokenRequest>();

            response.Result = new GetTokenRequest()
            {
                Email = "testB@testC.com",
                Password = "1234",
            };
            return View(response);
        }

        [ServiceFilter(typeof(WebTokenAuthorizationAttribute))]
        public IActionResult Register()
        {
            var response = new WebResponseDto<RegisterApplicationUserModel>()
            {
                Result = new RegisterApplicationUserModel()
                {
                    Email = "testB@testC.com",
                    Name = "test",
                    Surname = "test",
                    Password = "1234",
                    Repassword = "1234"
                }
            };

            return View(response);
        }

        [HttpPost]
        public IActionResult Register(RegisterApplicationUserModel model)
        {
            model.ActiveEntityOrganizationId = 1;
            var result = _connector.Authentication.Register(model);
            return Json(result);
        }

        [HttpPost]
        public IActionResult LoginAction(GetTokenRequest requestRequest)
        {
            var result = _connector.EndPoint.Request<GetTokenRequest, ApplicationUserContext>(requestRequest);

            var response = new ResponseModel<int>();
            response.Messages = result.Messages;

            if (result.Messages.Any(a => a.Type == MessageDtoType.Error))
                return Json(response, Helpers.Json.Serialization.Default());

            var key = Guid.NewGuid().ToString();
            HttpContext.Response.Cookies.Append("CSRF-TOKEN", key);

            _storage.Set(key, result.Result);

            response.SetRedirect("Redirect", Url.Action("Index", "Portfolios"), "Portfolios");

            return Json(response, Helpers.Json.Serialization.Default());
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
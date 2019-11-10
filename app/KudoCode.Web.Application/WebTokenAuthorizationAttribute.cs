using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.Web.Api.Connector;
using KudoCode.Web.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServiceStack.Redis;

namespace KudoCode.Web.Application
{
    public class WebTokenAuthorizationAttribute : ActionFilterAttribute
    {
        private readonly Connector _connector;
        private readonly IStorage _storage;

        public WebTokenAuthorizationAttribute(Connector connector, IStorage storage)
        {
            _connector = connector;
            _storage = storage;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Cookies.ContainsKey("CSRF-TOKEN"))
            {
                var key = filterContext.HttpContext.Request.Cookies["CSRF-TOKEN"];

                var context = _storage.Get<ApplicationUserContext>(key);
                _connector.Authentication.SetToken(context.Token);
                WebApplicationContext.ApplicationUserContext = context;
            }
            else
                filterContext.Result = new RedirectToActionResult("Index", "Home", new { });
        }
    }
}
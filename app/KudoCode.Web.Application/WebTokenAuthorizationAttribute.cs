using KudoCode.Contracts;
using KudoCode.Contracts.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KudoCode.Web.Application
{
	public class WebTokenAuthorizationAttribute : ActionFilterAttribute
    {
        private readonly Api.Connector.Connector _connector;
        private readonly IStorage _storage;

        public WebTokenAuthorizationAttribute(Api.Connector.Connector connector, IStorage storage)
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
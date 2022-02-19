using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace KudoCode.Abstract.Web.Blazor
{
	public class CsrfTokenCookieMiddleware
    {
        private readonly RequestDelegate _next;

        public CsrfTokenCookieMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies["CSRF-TOKEN"] == null)
            {
                context.Response.Cookies.Append("CSRF-TOKEN", Guid.NewGuid().ToString(),
                    new Microsoft.AspNetCore.Http.CookieOptions {HttpOnly = false});
            }

            await _next(context);
        }
    }
}
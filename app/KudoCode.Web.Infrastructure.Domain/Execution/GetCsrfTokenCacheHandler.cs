using System;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace KudoCode.Web.Infrastructure.Domain.Execution
{
    public class CsrfTokenCache : ITokenCache
    {
        private readonly IConfiguration _configuration;

        private readonly IHttpContextAccessor _contextAccessor;
//        private readonly HttpContext _context;

        public CsrfTokenCache(
            IConfiguration configuration,
            IHttpContextAccessor contextAccessor
            //HttpContext context
        )
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
//            _context = context;
        }

        public void Set(string token)
        {
			// this is set by the middleware when using server side
           // throw new NotImplementedException();
        }

        public string Get()
        {
            var token = _contextAccessor.HttpContext?.Request?.Cookies["CSRF-TOKEN"];
            return token ?? "";
        }
    }
}
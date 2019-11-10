using System;
using System.Linq;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace KudoCode.LogicLayer.Infrastructure.Token
{
    public class AuthTokenCache : ITokenCache
    {
        private readonly IConfiguration _configuration;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthTokenCache(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Set(string token)
        {
            throw new NotImplementedException();
        }

        public string Get()
        {
            return _httpContextAccessor.HttpContext.Request.Headers["Authorization"].Any()
                ? _httpContextAccessor.HttpContext.Request.Headers["Authorization"][0]
                : string.Empty;
        }
    }
}
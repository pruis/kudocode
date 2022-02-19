using System.Linq;
using KudoCode.Contracts;
using KudoCode.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace KudoCode.Contracts.Api
{
    public class ProxyTokenCache : ITokenCache
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _token;


        public ProxyTokenCache(
            IHttpContextAccessor httpContextAccessor
        )
        {
            _httpContextAccessor = httpContextAccessor;
            Source = "HttpContext";
        }

        public string Source { get; set; }

        public void Set(string token)
        {
            _token = token;
            Source = "";
        }

        public string Get()
        {
            if (Source.Equals("HttpContext"))
                return _httpContextAccessor.HttpContext.Request.Headers["Authorization"].Any()
                    ? _httpContextAccessor.HttpContext.Request.Headers["Authorization"][0]
                    : string.Empty;

            return !string.IsNullOrWhiteSpace(_token) ? _token : string.Empty;
        }
    }
}
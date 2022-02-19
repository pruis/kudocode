using KudoCode.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace KudoCode.Contracts.Api
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
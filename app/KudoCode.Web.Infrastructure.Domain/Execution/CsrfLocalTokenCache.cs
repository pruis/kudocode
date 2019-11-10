using System;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using Microsoft.Extensions.Configuration;

namespace KudoCode.Web.Infrastructure.Domain.Execution
{
    public class CsrfLocalTokenCache : ITokenCache
    {

        private readonly IConfiguration _configuration;
        private readonly IStorage _storage;

        public CsrfLocalTokenCache(
            IConfiguration configuration,
            IStorage storage
        )
        {
            _configuration = configuration;
            _storage = storage;
        }

        public void Set(string token)
        {
            Console.WriteLine(token);
            _storage.Set("CSRF-TOKEN", token);
        }

        public string Get()
        {
            var token = _storage.Get<string>("CSRF-TOKEN"); 
            Console.WriteLine(token);
            return token;
        }
    }
}
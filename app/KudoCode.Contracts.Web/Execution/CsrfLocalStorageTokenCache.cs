using System;
using KudoCode.Contracts;
using Microsoft.Extensions.Configuration;

namespace KudoCode.Contracts.Web
{
    public class CsrfLocalStorageTokenCache : ITokenCache
    {

        private readonly IConfiguration _configuration;
        private readonly IStorage _storage;

        public CsrfLocalStorageTokenCache(
            IConfiguration configuration,
            IStorage storage
        )
        {
            _configuration = configuration;
            _storage = storage;
        }

        public void Set(string token)
        {
            Console.WriteLine("Set Token");
            _storage.Set("CSRF-TOKEN", token);
        }

        public string Get()
        {
            var token = _storage.Get<string>("CSRF-TOKEN"); 
            Console.WriteLine("Get Token");
            return token;
        }
    }
}
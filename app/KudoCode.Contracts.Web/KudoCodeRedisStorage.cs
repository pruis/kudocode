using System;
using System.Xml.Schema;
using Microsoft.Extensions.Configuration;
using ServiceStack.Redis;

namespace KudoCode.Contracts.Web
{
    public class KudoCodeRedisStorage : IStorage
    {
        private readonly IConfiguration _configuration;

        public KudoCodeRedisStorage(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Remove(string key)
        {
            var redisUrl = _configuration["RedisUrl"];
            using (var client = new RedisManagerPool(redisUrl).GetClient())
                client.Remove(key);
        }

        public void Set(string key, object result)
        {
            var redisUrl = _configuration["RedisUrl"];
            using (var client = new RedisManagerPool(redisUrl).GetClient())
                client.Set(key, result, System.DateTime.Now.AddMinutes(int.Parse(_configuration["TokenExpireMin"])));
        }

        public T Get<T>(string key)
        {
            var redisUrl = _configuration["RedisUrl"];
            using (var client = new RedisManagerPool(redisUrl).GetClient())
                return client.Get<T>(key);
        }

        public T GetOrCreate<T>(string key)
        {
            T item = default;
            var redisUrl = _configuration["RedisUrl"];
            using (var client = new RedisManagerPool(redisUrl).GetClient())
                item = client.Get<T>(key);

            if (item == null)
                return Activator.CreateInstance<T>();
            return item;

        }
    }
}
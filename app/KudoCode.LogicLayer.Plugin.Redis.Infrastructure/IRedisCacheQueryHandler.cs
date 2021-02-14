using System;
using System.Collections.Generic;

namespace KudoCode.LogicLayer.Plugin.Redis.Infrastructure
{
    public interface IRedisCacheQueryHandler
    {
        string RedisKey();
    }

    public interface IRedisCacheCommandHandler
    {
        List<string> RedisKeys();
    }
    public interface IDelegateContext
    {
        List<string> Keys { get; set; }
    }
    public class DelegateContext : IDelegateContext
    {
        public DelegateContext()
        {
            Keys = new List<string>();
        }
        public List<string> Keys { get; set; }
    }
}
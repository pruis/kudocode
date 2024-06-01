using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

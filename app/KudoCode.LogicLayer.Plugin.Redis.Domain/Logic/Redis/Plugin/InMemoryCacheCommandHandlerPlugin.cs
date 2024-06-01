using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using ServiceStack.Redis;

namespace KudoCode.LogicLayer.Plugin.Redis.Domain.Logic.Redis.Plugin
{
    public class InMemoryCacheCommandHandlerPlugin<TRequestDto, TEntity, TOut> : ICommandHandlerDelegates<TRequestDto, TEntity, TOut>
    {
        private readonly ILifetimeScope _scope;
        private readonly IDelegateContext _redisContext;
        private readonly CommandHandlerDelegates<TRequestDto, TEntity, TOut> _commandHandlerDelegates;
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheCommandHandlerPlugin(
            CommandHandlerDelegates<TRequestDto, TEntity, TOut> commandHandlerDelegates,
            ILifetimeScope scope,
            IDelegateContext redisContext,
            IMemoryCache memoryCache
        )
        {
            _scope = scope;
            _redisContext = redisContext;
            _commandHandlerDelegates = commandHandlerDelegates;
            _commandHandlerDelegates.AfterExecute += Delete;
            _memoryCache = memoryCache;
        }

        private void Delete(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler)
        {
            if (!(handler is IRedisCacheCommandHandler) || handler.Context.HasErrors())
                return;

            ((IRedisCacheCommandHandler)handler).RedisKeys().ForEach(key =>
            {
                if (_memoryCache.TryGetValue(key, out _))
                {
                    _memoryCache.Remove(key);
                    _redisContext.Keys.Remove(key);
                }
            });
        }

        public void Dispose()
        {
            _commandHandlerDelegates.AfterExecute -= Delete;
        }
    }
}
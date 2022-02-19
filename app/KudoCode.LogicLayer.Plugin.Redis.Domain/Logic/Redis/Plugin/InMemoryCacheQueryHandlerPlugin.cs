using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using ServiceStack.Redis;

namespace KudoCode.LogicLayer.Plugin.Redis.Domain.Logic.Redis.Plugin
{
    public class InMemoryCacheQueryHandlerPlugin<TRequestDto, TEntity, TOut> : IQueryHandlerDelegates<TRequestDto, TEntity, TOut>
    {
        private readonly QueryHandlerDelegates<TRequestDto, TEntity, TOut> _queryHandlerDelegates;
        private readonly IMemoryCache _memoryCache;
        private readonly IDelegateContext _redisContext;

        public InMemoryCacheQueryHandlerPlugin(
            QueryHandlerDelegates<TRequestDto, TEntity, TOut> queryHandlerDelegates,
            IDelegateContext redisContext,
            IMemoryCache memoryCache
        )
        {
            _memoryCache = memoryCache;
            _redisContext = redisContext;
            _queryHandlerDelegates = queryHandlerDelegates;
            _queryHandlerDelegates.BeforeGetEntity += Get;
            _queryHandlerDelegates.AfterExecute += Set;
        }


        private void Get(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler)
        {
            if (!(handler is IRedisCacheQueryHandler) || handler.Context.HasErrors())
                return;

            var key = ((IRedisCacheQueryHandler)handler).RedisKey();
            TOut _;

            _memoryCache.TryGetValue<TOut>(key, out _);
            handler.Context.Result = _;
            if (handler.Context.Result == null) return;
            if (!_redisContext.Keys.Contains(key))
                _redisContext.Keys.Add(key);
        }

        private void Set(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler)
        {
            if (!(handler is IRedisCacheQueryHandler) || handler.Context.HasErrors())
                return;

            _memoryCache.Set(((IRedisCacheQueryHandler)handler).RedisKey(), handler.Context.Result);
        }

        public void Dispose()
        {
            _queryHandlerDelegates.BeforeGetEntity -= Get;
            _queryHandlerDelegates.AfterExecute -= Set;
        }
    }
}
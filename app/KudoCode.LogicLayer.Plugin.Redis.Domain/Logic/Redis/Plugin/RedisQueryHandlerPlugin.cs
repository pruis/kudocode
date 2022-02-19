using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;
using ServiceStack.Redis;

namespace KudoCode.LogicLayer.Plugin.Redis.Domain.Logic.Redis.Plugin
{
    public class RedisQueryHandlerPlugin<TRequestDto, TEntity, TOut> : IQueryHandlerDelegates<TRequestDto, TEntity, TOut>
    {
        private readonly QueryHandlerDelegates<TRequestDto, TEntity, TOut> _queryHandlerDelegates;
        private readonly IDelegateContext _redisContext;

        public RedisQueryHandlerPlugin(
            QueryHandlerDelegates<TRequestDto, TEntity, TOut> queryHandlerDelegates,
            IDelegateContext redisContext
        )
        {
            _redisContext = redisContext;
            _queryHandlerDelegates = queryHandlerDelegates;
            _queryHandlerDelegates.BeforeGetEntity += Get;
            _queryHandlerDelegates.AfterExecute += Set;
        }


        private void Get(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler)
        {
            if (!(handler is IRedisCacheQueryHandler) || handler.Context.HasErrors())
                return;

            using (var client = new RedisManagerPool("localhost:6379").GetClient())
            {
                //IRedisCacheHandler
                var key = ((IRedisCacheQueryHandler) handler).RedisKey();
                handler.Context.Result = client.Get<TOut>(key);
                if (handler.Context.Result == null) return;
                if (!_redisContext.Keys.Contains(key))
                    _redisContext.Keys.Add(key);
            }
        }

        private void Set(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler)
        {
            if (!(handler is IRedisCacheQueryHandler) || handler.Context.HasErrors())
                return;

            using (var client = new RedisManagerPool("localhost:6379").GetClient())
                client.Set(((IRedisCacheQueryHandler) handler).RedisKey(), handler.Context.Result);
        }

        public void Dispose()
        {
            _queryHandlerDelegates.BeforeGetEntity -= Get;
            _queryHandlerDelegates.AfterExecute -= Set;
        }
    }
}
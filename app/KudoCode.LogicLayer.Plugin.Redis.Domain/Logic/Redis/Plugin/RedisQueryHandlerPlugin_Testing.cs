using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;

namespace KudoCode.LogicLayer.Plugin.Redis.Domain.Logic.Redis.Plugin
{
	public class
        RedisQueryHandlerPlugin_Testing<TRequestDto, TEntity, TOut> : IQueryHandlerDelegates<TRequestDto, TEntity, TOut>
    {
        private readonly QueryHandlerDelegates<TRequestDto, TEntity, TOut> _queryHandlerDelegates;
        private readonly IDelegateContext _redisContext;

        public RedisQueryHandlerPlugin_Testing(
            QueryHandlerDelegates<TRequestDto, TEntity, TOut> queryHandlerDelegates,
            IDelegateContext redisContext
        )
        {
            _redisContext = redisContext;
            _queryHandlerDelegates = queryHandlerDelegates;
        }





        public void Dispose()
        {

        }
    }
}
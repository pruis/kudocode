using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;
using ServiceStack.Redis;

namespace KudoCode.LogicLayer.Plugin.Redis.Domain.Logic.Redis.Plugin
{
    public class RedisCommandHandlerPlugin<TRequestDto, TEntity, TOut> : ICommandHandlerDelegates<TRequestDto, TEntity, TOut>
    {
        private readonly ILifetimeScope _scope;
        private readonly IDelegateContext _redisContext;
        private readonly CommandHandlerDelegates<TRequestDto, TEntity, TOut> _commandHandlerDelegates;

        public RedisCommandHandlerPlugin(
            CommandHandlerDelegates<TRequestDto, TEntity, TOut> commandHandlerDelegates,
            ILifetimeScope scope,
            IDelegateContext redisContext
        )
        {
            _scope = scope;
            _redisContext = redisContext;
            _commandHandlerDelegates = commandHandlerDelegates;
            _commandHandlerDelegates.AfterExecute += Delete;
        }

        private void Delete(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler)
        {
            if (!(handler is IRedisCacheCommandHandler) || handler.Context.HasErrors())
                return;

            using (var client = new RedisManagerPool("localhost:6379").GetClient())
                ((IRedisCacheCommandHandler) handler).RedisKeys().ForEach(key =>
                {
                    var value = client.ContainsKey(key);
                    client.Remove(key);
                    _redisContext.Keys.Remove(key);
                });
        }

        public void Dispose()
        {
            _commandHandlerDelegates.AfterExecute -= Delete;
        }
    }
}
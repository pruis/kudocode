using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;

namespace KudoCode.LogicLayer.Plugin.Redis.Domain.Logic.Redis.Plugin
{
	public class
        RedisCommandHandlerPlugin_Testing<TRequestDto, TEntity, TOut> : ICommandHandlerDelegates<TRequestDto, TEntity, TOut>
    {
        private readonly ILifetimeScope _scope;
        private readonly IDelegateContext _redisContext;
        private readonly CommandHandlerDelegates<TRequestDto, TEntity, TOut> _commandHandlerDelegates;

        public RedisCommandHandlerPlugin_Testing(
            CommandHandlerDelegates<TRequestDto, TEntity, TOut> commandHandlerDelegates,
            ILifetimeScope scope,
            IDelegateContext redisContext
        )
        {
            _scope = scope;
            _redisContext = redisContext;
            _commandHandlerDelegates = commandHandlerDelegates;
        }

        public void Dispose()
        {
        }
    }
}
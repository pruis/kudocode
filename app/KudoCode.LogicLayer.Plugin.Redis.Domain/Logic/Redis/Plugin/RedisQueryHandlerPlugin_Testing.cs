using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;
using Newtonsoft.Json;
using ServiceStack;
using ServiceStack.Redis;

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
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.Contracts.Api
{
	public abstract class QueryHandler<TRequestDto, TEntity, TOut> :
        AbstractEntityHandler<TRequestDto, TEntity, TOut>
        where TEntity : class 
    {
        protected readonly IReadOnlyRepository Repository;

        private QueryHandlerDelegates<TRequestDto, TEntity, TOut> HandlerDelegates { get; }

        public override IWorkerContext<TOut> Handle(TRequestDto request)
        {
            Request = request;
            HandlerDelegates.BeforeGetEntity(this);

			if (this is IRedisCacheQueryHandler
			&& Scope.Resolve<IDelegateContext>().Keys.Contains(((IRedisCacheQueryHandler)this).RedisKey()))
			{
				return Context;
			}

			GetEntity();
            HandlerDelegates.AfterGetEntity(this);
            if (Context.HasErrors())
                return Context;

            ValidateEntity();
            if (Context.HasErrors())
                return Context;

            HandlerDelegates.BeforeExecute(this);
            this.Execute();
            HandlerDelegates.AfterExecute(this);

            return Context;
        }

        protected QueryHandler(
            IMapper mapper,
            IReadOnlyRepository repository,
            IComponentContext scope,
            IWorkerContext<TOut> context) : base(
            mapper, context, scope)
        {
            Repository = repository;
            HandlerDelegates = scope.Resolve<QueryHandlerDelegates<TRequestDto, TEntity, TOut>>();
            scope.Resolve<IEnumerable<IQueryHandlerDelegates<TRequestDto, TEntity, TOut>>>().ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Handlers
{
    public abstract class QueryHandler<TRequestDto, TEntity, TOut> :
        AbstractEntityHandler<TRequestDto, TEntity, TOut>
        where TEntity : class //, IEntity
    {
        protected readonly IReadOnlyRepository Repository;

        private QueryHandlerDelegates<TRequestDto, TEntity, TOut> HandlerDelegates { get; }

        public override IWorkerContext<TOut> Handle(TRequestDto request)
        {
            Request = request;
            HandlerDelegates.BeforeGetEntity(this);
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
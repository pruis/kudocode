using Autofac;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.Contracts.Api
{
	public abstract class CommandHandler<TRequestDto, TEntity, TOut>
        : AbstractEntityHandler<TRequestDto, TEntity, TOut>
        where TEntity : class //, IEntity
        where TRequestDto : class
    {
        protected readonly IRepository Repository;
        private CommandHandlerDelegates<TRequestDto, TEntity, TOut> HandlerDelegates { get; }

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
            Execute();
            HandlerDelegates.AfterExecute(this);

            return Context;
        }

        protected CommandHandler(IMapper mapper, IRepository repository, IComponentContext scope,
            IWorkerContext<TOut> context) : base(mapper, context, scope)
        {
            Repository = repository;
            HandlerDelegates = scope.Resolve<CommandHandlerDelegates<TRequestDto, TEntity, TOut>>();
            scope.Resolve<IEnumerable<ICommandHandlerDelegates<TRequestDto, TEntity, TOut>>>().ToList();
        }
    }
}
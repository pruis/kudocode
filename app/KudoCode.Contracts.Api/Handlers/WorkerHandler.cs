using Autofac;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.Contracts.Api
{
	public abstract class WorkerHandler<TRequestDto, TOut> :
        AbstractHandler<TRequestDto, TOut>
    {
        public override IWorkerContext<TOut> Handle(TRequestDto request)
        {
            Request = request;
            HandlerDelegates.BeforeGetEntity(this);
            GetEntity();
            HandlerDelegates.AfterGetEntity(this);
            HandlerDelegates.BeforeExecute(this);
            Execute();
            HandlerDelegates.AfterExecute(this);
            return Context;
        }

        protected virtual void GetEntity()
        {
        }


        protected WorkerHandler(IMapper mapper, IComponentContext scope,
            IWorkerContext<TOut> context) : base(mapper, context, scope)
        {
            HandlerDelegates = scope.Resolve<WorkerHandlerDelegates<TRequestDto, TOut>>();
            scope.Resolve<IEnumerable<IWorkerHandlerDelegates<TRequestDto, TOut>>>().ToList();
        }

        public WorkerHandlerDelegates<TRequestDto, TOut> HandlerDelegates { get; set; }
    }
}
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using log4net;

namespace KudoCode.LogicLayer.Infrastructure.Handlers
{
    public interface IAbstractHandler<TRequestDto, TOut>
    {
        TRequestDto Request { get; set; }
        IWorkerContext<TOut> Context { get; }
    }

    public abstract class AbstractHandler<TRequestDto, TOut>
        : IAbstractHandler<TRequestDto, TOut>,
            IHandler<TRequestDto, IWorkerContext<TOut>>
    {
        protected readonly IMapper Mapper;
        public ILog Log { get; set; }

        protected AbstractHandler(IMapper mapper, IWorkerContext<TOut> context, IComponentContext scope)
        {
            Mapper = mapper;
            Context = context;
            Scope = scope;
        }

        public abstract IWorkerContext<TOut> Handle(TRequestDto request);

        protected virtual void Execute()
        {
        }

        public TRequestDto Request { get; set; }
        public IWorkerContext<TOut> Context { get; }
        protected IComponentContext Scope { get; }
    }
}
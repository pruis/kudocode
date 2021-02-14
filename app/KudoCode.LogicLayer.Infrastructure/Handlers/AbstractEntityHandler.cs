using System.Collections.Generic;
using System.IO;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Handlers
{
    public interface IAbstractEntityHandler<TRequestDto, TEntity, TOut> : IAbstractHandler<TRequestDto, TOut>
    {
        TEntity Entity { get; set; }
    }

    public abstract class AbstractEntityHandler<TRequestDto, TEntity, TOut> : AbstractHandler<TRequestDto, TOut>
        , IAbstractEntityHandler<TRequestDto, TEntity, TOut>
    {
        protected AbstractEntityHandler(IMapper mapper, IWorkerContext<TOut> context, IComponentContext scope)
            : base(mapper, context, scope)
        {
        }

        protected virtual void GetEntity()
        {
        }

        protected virtual void ValidateEntity()
        {
        }

        public TEntity Entity { get; set; }
    }
}
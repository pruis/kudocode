using Autofac;
using AutoMapper;

namespace KudoCode.Contracts.Api
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
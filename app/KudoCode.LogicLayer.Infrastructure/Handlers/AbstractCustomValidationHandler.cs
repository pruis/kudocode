using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Handlers
{
	public abstract class AbstractCustomValidationHandler<TDto, TOut> : IHandler<TDto, ICustomValidationContext<TOut>>
	{
		public AbstractCustomValidationHandler(ICustomValidationContext<TOut> context)
		{
			Context = context;
		}

		public abstract void Execute();

		public ICustomValidationContext<TOut> Handle(TDto request)
		{
			Dto = request;
			this.Execute();
			return Context;
		}

		public TDto Dto { get; set; }
		public ICustomValidationContext<TOut> Context { get; }
	}
}
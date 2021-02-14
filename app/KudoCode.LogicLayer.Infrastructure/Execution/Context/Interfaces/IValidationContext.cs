using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;

namespace KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces
{
	public interface IValidationContext<TOut> : IMessagesContext, IEventsContext<TOut>, IHasErrorsContext<TOut>
	{

	}
}
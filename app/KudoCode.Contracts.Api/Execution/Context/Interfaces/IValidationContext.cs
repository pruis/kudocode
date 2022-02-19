using KudoCode.Contracts;

namespace KudoCode.Contracts.Api
{
	public interface IValidationContext<TOut> : IMessagesContext, IEventsContext<TOut>, IHasErrorsContext<TOut>
	{

	}
}
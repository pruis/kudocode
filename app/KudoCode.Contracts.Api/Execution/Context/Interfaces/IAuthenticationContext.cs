using KudoCode.Contracts;

namespace KudoCode.Contracts.Api
{
	public interface IAuthenticationContext<TOut> : IMessagesContext, IEventsContext<TOut>, IHasErrorsContext<TOut>
	{
	}
}
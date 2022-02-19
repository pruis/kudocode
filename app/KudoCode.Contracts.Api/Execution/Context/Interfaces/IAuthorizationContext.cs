using KudoCode.Contracts;

namespace KudoCode.Contracts.Api
{
	public interface IAuthorizationContext<TOut> : IMessagesContext, IEventsContext<TOut>, IHasErrorsContext<TOut>, IIsLoggedinContext
	{
	}
}
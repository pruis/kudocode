using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;

namespace KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces
{
	public interface IAuthorizationContext<TOut> : IMessagesContext, IEventsContext<TOut>, IHasErrorsContext<TOut>, IIsLoggedinContext
	{
	}
}
using System.Collections;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces
{

	public interface IWorkerContext<TOut> :
		IMessagesContext,
		IEventsContext<TOut>,
		IHasErrorsContext<TOut>,
		IIsLoggedinContext
	{
		TOut Result { get; set; }

		ArrayList Aggregates { get; set; }
		void RaiseAggregate<TAggRequest, TAggResponse>(TAggRequest dto, params string[] queues)
			where TAggRequest : IApiRequestDto;
	}
}
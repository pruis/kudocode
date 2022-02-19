using System.Collections;
using KudoCode.Contracts;
using KudoCode.Contracts;

namespace KudoCode.Contracts.Api
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
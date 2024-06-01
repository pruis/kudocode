using System.Collections;
using KudoCode.Contracts;

namespace KudoCode.Contracts.Api
{
	public interface IEventsContext<TOut>
	{
		ArrayList Events { get; set; }
		void RaiseEvent<T>(T @event, params string[] queues) where T : IEventMetaData;
	}
}
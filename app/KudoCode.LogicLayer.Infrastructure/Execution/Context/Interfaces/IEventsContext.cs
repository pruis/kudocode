using System.Collections;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces
{
	public interface IEventsContext<TOut>
	{
		ArrayList Events { get; set; }
		void RaiseEvent<T>(T @event, params string[] queues) where T : IEventMetaData;
	}
}
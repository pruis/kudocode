using System.Collections;
using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;

namespace KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces
{
	public interface IValidationContext<TOut>
	{
		List<MessageDto> Messages { get; set; }
		void AddMessage(string key, string[] values = null);

		ArrayList Events{ get; set; }
		void RaiseEvent<T>(T @event, params string[] queues) where T : IEventMetaData;
		bool HasErrors();

	}
}
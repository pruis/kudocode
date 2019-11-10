using System.Collections;
using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;

namespace KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces
{

	public interface IAuthenticationContext<TOut>
	{
		List<MessageDto> Messages { get; set; }
		ArrayList Events{ get; set; }
		void AddMessage(string key, string[] values = null);
		void RaiseEvent<T>(T @event, params string[] queues) where T : IEventMetaData;
		bool HasErrors();
		bool IsValidTokenProvided { get; set; }
	}
	public interface IAuthorizationContext<TOut>
	{
		List<MessageDto> Messages { get; set; }
		ArrayList Events{ get; set; }
		void AddMessage(string key, string[] values = null);
		void RaiseEvent<T>(T @event, params string[] queues) where T : IEventMetaData;
		bool HasErrors();
		bool IsLoggedIn();
	}
}
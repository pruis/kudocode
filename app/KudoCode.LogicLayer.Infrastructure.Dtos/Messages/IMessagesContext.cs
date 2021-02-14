using System.Collections.Generic;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.Messages
{
	public interface IMessagesContext
	{
		List<MessageDto> Messages { get; set; }
		void AddMessage(string key, params string[] values);
	}
}
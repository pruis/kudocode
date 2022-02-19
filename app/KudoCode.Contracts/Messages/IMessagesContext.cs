using System.Collections.Generic;

namespace  KudoCode.Contracts
{
	public interface IMessagesContext
	{
		List<MessageDto> Messages { get; set; }
		void AddMessage(string key, params string[] values);
	}
}
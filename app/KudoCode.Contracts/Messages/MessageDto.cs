using System.Collections.Generic;

namespace KudoCode.Contracts
{
	public interface IMessageCollection
	{
		IReadOnlyCollection<MessageDto> Messages { get; }
	}

	public class MessageDto : IMessageDto
	{
		public MessageDto(string key, string message, MessageDtoType type)
		{
			Key = key;
			Message = message;
			Type = type;
		}

		public string Key { get; set; }
		public string Message { get; set; }
		public MessageDtoType Type { get; set; }
	}

	public enum MessageDtoType
	{
		Error = 1,
		Warning = 2,
		Success = 3,
		Information = 4
	}
}
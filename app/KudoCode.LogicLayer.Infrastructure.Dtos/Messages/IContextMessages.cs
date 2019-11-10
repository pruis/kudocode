using System.Collections.Generic;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.Messages
{
	public interface IContextMessages
	{
		List<MessageDto> Messages { get; set; }
	}
}
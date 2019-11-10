using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;

namespace KudoCode.LogicLayer.Infrastructure.Messages
{
	public interface IMessageCollection
	{
		IReadOnlyCollection<MessageDto> Messages { get; }
	}
}
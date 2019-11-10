using System.Collections.Generic;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.Events.Interfaces
{
	public interface IEventRequestDto<T> where T : IEventMetaData
	{
		T MetaData { get; set; }
		List<string> Queues { get; set; }
	}
}
using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.Events
{
	public class EventRequestDto<T> : IEventRequestSources, IEventRequestDto<T> 
		where T : IEventMetaData
	{
		public EventRequestDto()
		{
			Queues = new List<string>();
		}
		public T MetaData { get; set; }
		public List<string> Queues { get; set; }
	}
}

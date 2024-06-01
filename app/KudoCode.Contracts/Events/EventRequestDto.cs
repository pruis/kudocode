using System.Collections.Generic;

namespace KudoCode.Contracts
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

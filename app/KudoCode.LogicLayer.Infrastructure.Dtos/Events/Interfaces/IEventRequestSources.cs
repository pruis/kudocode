using System.Collections.Generic;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.Events.Interfaces
{
	public interface IEventRequestSources
	{
		List<string> Queues { get; set; }
	}
}

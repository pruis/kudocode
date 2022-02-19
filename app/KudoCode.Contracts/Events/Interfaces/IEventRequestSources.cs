using System.Collections.Generic;

namespace  KudoCode.Contracts
{
	public interface IEventRequestSources
	{
		List<string> Queues { get; set; }
	}
}

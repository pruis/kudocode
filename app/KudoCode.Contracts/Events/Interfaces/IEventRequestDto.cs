using System.Collections.Generic;

namespace  KudoCode.Contracts
{
	public interface IEventRequestDto<T> //where T : IEventMetaData
	{
		T MetaData { get; set; }
		List<string> Queues { get; set; }
	}
}
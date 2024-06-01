using System.Collections.Generic;

namespace KudoCode.Contracts
{
	public interface IListResponse<T>
	{
		List<T> List { get; set; }
	}

}

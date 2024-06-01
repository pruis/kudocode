using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudoCode.Contracts
{
	public class SaveChildTableConfigRequest : IApiRequestDto
	{
		public int Id { get; set; }
		public int TableConfigId { get; set; }
		public int ChildConfigId { get; set; }
	}
	public class SaveChildTableConfigResponse
	{
		public int Id { get; set; }
	}
	public class ListChildTableConfigResponse : IListResponse<ChildTableConfig>
	{
		public ListChildTableConfigResponse()
		{
			List = new List<ChildTableConfig>();
		}

		public List<ChildTableConfig> List { get; set; }
	}
	public class ListChildTableConfigRequest : IApiRequestDto
	{
		public ListChildTableConfigRequest()
		{

		}
		public int TableConfigId { get; set; }
	}
	public class DeleteChildTableConfigRequest
	{
		public int Id { get; set; }
	}
	public class DeleteChildTableConfigResponse
	{
	}
	public class GetChildTableConfigResponse
	{
		public int Id { get; set; }
		[VxIgnore]
		public int TableConfigId { get; set; }
		public int ChildConfigId { get; set; }

	}
	public class GetChildTableConfigRequest : IApiRequestDto
	{
		public GetChildTableConfigRequest()
		{
		}
		public int Id { get; set; }

	}
}

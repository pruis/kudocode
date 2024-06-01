using KudoCode.Contracts.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudoCode.Abstract.Application
{
	public class Dynamic : IEntity
	{
		public int Id { get; set; }
		public int TableConfigId { get; set; }
		public int? DynamicId { get; set; }
		public string Data { get; set; }
	}
}

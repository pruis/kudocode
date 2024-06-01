using KudoCode.Contracts.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudoCode.Abstract.Application
{
	public class TableConfig : IEntity
	{
		public TableConfig()
		{
			Properties = new List<PropertyConfig>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public string GetInterceptorKey { get; set; }
		public string SaveInterceptorKey { get; set; }
		public string ListInterceptorKey { get; set; }
		public List<PropertyConfig> Properties { get; set; }
		public List<ChildTableConfig> ChildTableConfigs { get; set; }

	}

	public class PropertyConfig : IEntity
	{
		public PropertyConfig()
		{
		}

		public int TableConfigId { get; set; }
		public TableConfig TableConfig { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public int Id { get; set; }
		public string Source { get; set; }
		public bool CacheOnFirstLoad { get; set; }
		public string Filter { get; set; }

	}
	public class ChildTableConfig : IEntity
	{
		public ChildTableConfig()
		{
		}

		public TableConfig TableConfig { get; set; }
		public int TableConfigId { get; set; }
		public int ChildConfigId { get; set; }
		public int Id { get; set; }
	}
}

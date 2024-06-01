using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using KudoCode.Helpers;
using System.Linq;

namespace KudoCode.Contracts
{
	public interface IListTableConfigStore
	{
		List<TableConfig> List { get; set; }
	}

	public class ListTableConfigStore : IListTableConfigStore
	{
		public ListTableConfigStore()
		{
			List = new List<TableConfig>();
		}

		public List<TableConfig> List { get; set; }
	}

	public class ConvertToObjectDictionary : IConvertToObjectDictionary
	{
		public ConvertToObjectDictionary()
		{
			List = new Dictionary<string, Type>
			{
				{ "string", typeof(string) },
				{ "datetime", typeof(DateTime) },
				{ "int", typeof(int) },
				{ "checkbox", typeof(bool) },
				{ "dropdown", typeof(VxLookup) },
			};
		}

		private Dictionary<string, Type> List { get; set; }

		public void Set(Dictionary<string, Type> List)
		{

			this.List = List;
		}
		public Type GetType(string key)
		{
			Type T;
			var success = List.TryGetValue(key, out T);

			if (!success)
				return typeof(string);

			return T;
		}
	}


	public interface IConvertToObjectDictionary
	{
		Type GetType(string key);
	}

	public interface IConvertToObject
	{
		object ToObject(string data, int tableConfigId, Type type);
		object NewObject(int tableConfigId, Type type);
		Type GeTypeFromConfig(int tableConfigId);

	}

	public class ConvertToObject : IConvertToObject
	{
		private readonly IListTableConfigStore _listTableConfigStore;
		private readonly IConvertToObjectDictionary _typeDict;

		public ConvertToObject(IConvertToObjectDictionary typeDict, IListTableConfigStore listTableConfigStore)
		{
			_listTableConfigStore = listTableConfigStore;
			_typeDict = typeDict;
		}

		public object ToObject(string data, int tableConfigId, Type type)
		{
			return JsonConvert.DeserializeObject(data, type);
		}
		public object NewObject(int tableConfigId, Type type)
		{
			return Activator.CreateInstance(type);
		}

		public Type GeTypeFromConfig(int tableConfigId)
		{
			List<(string, Type)> list = new();
			_listTableConfigStore.List.Single(a => a.Id == tableConfigId).Properties.ForEach((prop) =>
			{
				list.Add(new(prop.Name, _typeDict.GetType(prop.Type)));
			});
			var type = new MyClassBuilder().CreateType<object>("edit", list);

			return type;
		}
	}



	public class SaveTableConfigRequest : IApiRequestDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string GetInterceptorKey { get; set; }
		public string SaveInterceptorKey { get; set; }
		public string ListInterceptorKey { get; set; }


	}
	public class SaveTableConfigResponse
	{
		public int Id { get; set; }
	}

	public class ListTableConfigResponse : IListResponse<TableConfig>
	{
		public ListTableConfigResponse()
		{
			List = new List<TableConfig>();
		}

		public List<TableConfig> List { get; set; }
	}
	public class ListTableConfigRequest : IApiRequestDto
	{
		public ListTableConfigRequest()
		{
		}
	}
	public class TableConfigModel
	{
		public TableConfigModel()
		{

		}
		public int TableConfigId { get; set; }
	}

	public class DeleteTableConfigRequest
	{
		public int Id { get; set; }
	}
	public class DeleteTableConfigResponse
	{
	}
	public class GetTableConfigResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string GetInterceptorKey { get; set; }
		public string SaveInterceptorKey { get; set; }
		//[VxFormGroup("test",0)]
		public string ListInterceptorKey { get; set; }

	}
	public class GetTableConfigRequest : IApiRequestDto
	{
		public GetTableConfigRequest()
		{
		}
		public int Id { get; set; }

	}

	public class SaveDynamicRequest : IApiRequestDto
	{
		public int TableConfigId { get; set; }
		public string Data { get; set; }
		public int? DynamicId { get; set; }
		public string InterceptorKey { get; set; }
	}
	public class SaveDynamicResponse
	{
		public string Data { get; set; }
	}

	public class ListDynamicResponse
	{ public List<string> Data { get; set; } }
	public record ListDynamicRequest : IApiRequestDto
	{
		public ListDynamicRequest()
		{
		}

		public int TableConfigId { get; set; }
		public int? DynamicId { get; set; }

	}

	public class GetDynamicResponse
	{ public string Data { get; set; } }
	public class GetDynamicRequest : IApiRequestDto
	{
		public GetDynamicRequest()
		{
			Parameters = new Dictionary<string, string>();
		}

		public Dictionary<string, string> Parameters { get; set; }
		public int Id { get; set; }

		public GetDynamicRequest Add(string key, string value)
		{
			Parameters.Add(key, value);
			return this;
		}
	}

	public class SavePropertyConfigRequest : IApiRequestDto
	{
		public int Id { get; set; }
		public int TableConfigId { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string Source { get; set; }
		public bool CacheOnFirstLoad { get; set; }
		public string Filter { get; set; }

	}
	public class SavePropertyConfigResponse
	{
		public int Id { get; set; }
	}
	public class ListPropertyConfigResponse : IListResponse<PropertyConfig>
	{
		public ListPropertyConfigResponse()
		{
			List = new List<PropertyConfig>();
		}

		public List<PropertyConfig> List { get; set; }
	}
	public class ListPropertyConfigRequest : IApiRequestDto
	{
		public ListPropertyConfigRequest()
		{

		}
		public int TableConfigId { get; set; }
	}
	public class DeletePropertyConfigRequest
	{
		public int Id { get; set; }
	}
	public class DeletePropertyConfigResponse
	{
	}
	public class GetPropertyConfigResponse
	{
		public int Id { get; set; }
		[VxIgnore]
		public int TableConfigId { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string Source { get; set; }
		public bool CacheOnFirstLoad { get; set; }
		public string Filter { get; set; }


	}
	public class GetPropertyConfigRequest : IApiRequestDto
	{
		public GetPropertyConfigRequest()
		{
		}
		public int Id { get; set; }
		public string Name { get; set; }

	}


	public class LoadTableConfigResponse
	{
		public LoadTableConfigResponse()
		{
			List = new List<TableConfig>();
		}

		public List<TableConfig> List { get; set; }
	}
	public class LoadTableConfigRequest : IApiRequestDto
	{
		public LoadTableConfigRequest()
		{
		}
	}


	public class TableConfig
	{
		public TableConfig()
		{
			Properties = new List<PropertyConfig>();
			ChildTableConfigs = new List<ChildTableConfig>();
		}
		[VxIgnore]
		public int Id { get; set; }
		public string Name { get; set; }
		[VxIgnore]
		public List<PropertyConfig> Properties { get; set; }
		[VxIgnore]
		public List<ChildTableConfig> ChildTableConfigs { get; set; }
		public string GetInterceptorKey { get; set; }
		public string SaveInterceptorKey { get; set; }
		public string ListInterceptorKey { get; set; }
	}

	public class PropertyConfig
	{
		public PropertyConfig()
		{
		}
		public PropertyConfig(string name, string type)
		{
			Name = name;
			Type = type;
		}

		[VxIgnore]
		public int Id { get; set; }
		[VxIgnore]
		public int TableConfigId { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string Source { get; set; }
		public bool CacheOnFirstLoad { get; set; }
		public string Filter { get; set; }

	}

	public class ChildTableConfig
	{
		public ChildTableConfig()
		{
		}

		[VxIgnore]
		public int Id { get; set; }
		[VxIgnore]
		public int TableConfigId { get; set; }
		public int ChildConfigId { get; set; }
	}


}


using KudoCode.Contracts;
using System;
using System.Reflection;

namespace KudoCode.Abstract.Web.Blazor
{
	public class VxFormElementDefinition
	{


		public string Name { get; private set; }
		public VxFormElementLayoutAttribute RenderOptions { get; set; }
		public object Model { get; private set; }
		public TableConfig TableConfig { get; }

		public VxFormElementDefinition(string fieldname, VxFormElementLayoutAttribute layoutAttr, object modelInstance, TableConfig tableConfig)
		{
			RenderOptions = layoutAttr;
			Name = fieldname;
			Model = modelInstance;
			TableConfig = tableConfig;
		}


		internal static VxFormElementDefinition Create(string fieldname, VxFormElementLayoutAttribute layoutAttr, object modelInstance, VxFormLayoutOptions options, TableConfig tableConfig)
		{
			return new VxFormElementDefinition(fieldname, layoutAttr, modelInstance, tableConfig);
		}
	}
}

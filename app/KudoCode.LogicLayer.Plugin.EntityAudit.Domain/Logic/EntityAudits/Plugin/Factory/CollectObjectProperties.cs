using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using KudoCode.LogicLayer.Plugin.EntityAudit.Dtos;

namespace KudoCode.LogicLayer.Plugin.EntityAudit.Domain.Logic.EntityAudits.Plugin.Factory
{
	public class CollectObjectProperties : ICollectObjectProperties
	{
		public CollectObjectProperties()
		{
			PropertyInformations = new List<PropertyInformationDto>();
		}

		public List<PropertyInformationDto> PropertyInformations
		{
			get; set;
		}


		public List<PropertyInformationDto> Get(object obj, string parentName = "")
		{
			try
			{
				if (obj == null)
					return  new List<PropertyInformationDto>();
				foreach (var property in obj.GetType().GetProperties())
				{
					//for value types
					if (property.PropertyType.IsPrimitive || property.PropertyType.IsValueType || property.PropertyType == typeof(string))
					{
						var propName = property.Name;
						if (!string.IsNullOrEmpty(parentName))
							propName = $"{parentName}.{propName}";

						PropertyInformations.Add(new PropertyInformationDto { Name = propName, Value = property.GetValue(obj)?.ToString() });
					}
					//for complex types
					else if (property.PropertyType.IsClass && !typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
						PropertyInformations.AddRange( new CollectObjectProperties().Get(property.GetValue(obj), property.Name));
					//for Enumerables
					else
					{
						var enumerablePropObj1 = property.GetValue(obj) as IEnumerable;

						if (enumerablePropObj1 == null)
							continue;

						var objList = enumerablePropObj1.GetEnumerator();

						while (objList.MoveNext())
							PropertyInformations.AddRange(new CollectObjectProperties().Get(objList.Current, property.Name));
					}
				}
				//for value types
//				if (obj.GetType().IsPrimitive || obj.GetType().IsValueType || obj is string)
//				{
//					var propName = property.Name;
//					if (!string.IsNullOrEmpty(parentName))
//						propName = $"{parentName}.{propName}";
//
//					PropertyInformations.Add(new PropertyInformationDto { Name = propName, Value = property.GetValue(obj)?.ToString() });
//				}
				return PropertyInformations;
			}
			catch (Exception)
			{
				//Debugger.Break();
				throw;
			}

		}
	}
}

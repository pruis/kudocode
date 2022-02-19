using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace KudoCode.Helpers
{
	public static class AutoMapperHelpers
	{
		public static decimal ToDecimalInvariant(this string input)
		{
			return decimal.Parse(input, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		public static string ToStringInvariant(this decimal input)
		{
			return input.ToString(CultureInfo.InvariantCulture);
		}

		public static string ToDecimal(this string input, string format)
		{
			var d = decimal.Parse(input, NumberStyles.Any, CultureInfo.InvariantCulture);
			return d.ToString(format, CultureInfo.InvariantCulture);
		}
	}

	public static class StaticHelpers
	{
		public static void Copy<TParent, TChild>(TParent src, TChild dest) where TParent : class
										where TChild : class
		{
			var parentProperties = src.GetType().GetProperties();
			var childProperties = dest.GetType().GetProperties();

			foreach (var parentProperty in parentProperties)
			{
				foreach (var childProperty in childProperties)
				{
					if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
					{
						childProperty.SetValue(dest, parentProperty.GetValue(src));
						break;
					}
				}
			}
		}
		//TODO unit test
		public static Type GetBusinessDtoType(string typeName)
		{
			if (typeName.ToLower().Contains("system.int32"))
				return typeof(int);

			var assemblies = AppDomain.CurrentDomain.GetAssemblies()
				.Where(a => a.FullName.Contains(".Dtos") || a.FullName.Contains(".Contracts")).ToList();

			foreach (var assembly in assemblies)
			{
				var t = assembly.GetTypes().SingleOrDefault(a => a.Name.Equals(typeName));
				if (t != null)
					return t;
			}

			throw new ArgumentException(
				"Type " + typeName + " doesn't exist in the current app domain");
		}
		public static string DictionaryToString(this IDictionary<string, string> dictionary)
		{
			string dictionaryString = "{";
			foreach (KeyValuePair<string, string> keyValues in dictionary)
			{
				dictionaryString += keyValues.Key + " : " + keyValues.Value + ", ";
			}
			return dictionaryString.TrimEnd(',', ' ') + "}";
		}
		public static IDictionary<string, string> ToDictionary(this object values)
		{
			var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

			if (values != null)
			{
				foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(values))
				{
					object obj = propertyDescriptor.GetValue(values);
					var value = "";
					if (obj != null)
						value = obj.ToString();
					dict.Add(propertyDescriptor.Name, value);
				}
			}

			return dict;
		}


	}
}
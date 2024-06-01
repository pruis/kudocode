using KudoCode.Contracts;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace KudoCode.Abstract.Web.Blazor.Layout
{

    public class VxFormGroup
	{

		public string Label { get; set; }

		public string Id { get; set; }

		public List<VxFormRowLayout> Rows { get; set; } = new List<VxFormRowLayout>();

		internal static bool IsFormGroup(PropertyInfo propertyInfo)
		{
			return propertyInfo.GetCustomAttribute<VxFormGroupAttribute>() != null;
		}

		internal static VxFormGroupAttribute GetFormGroup(PropertyInfo propertyInfo)
		{
			return propertyInfo.GetCustomAttribute<VxFormGroupAttribute>();
		}

		internal static VxFormGroup CreateFromModel(object modelInstance, TableConfig tableConfig)
		{
			return CreateFromModel(modelInstance, new VxFormLayoutOptions(), tableConfig);
		}

		internal static VxFormGroup CreateFromModel(object modelInstance, VxFormLayoutOptions options, TableConfig tableConfig)
		{
			var typeToCheck = modelInstance.GetType();
			// check for generics
			if (typeToCheck.IsGenericType)
				typeToCheck = typeToCheck.GetGenericTypeDefinition();

			var allProperties = VxHelpers.GetModelProperties(typeToCheck);

			var rootGroup = VxFormGroup.Create();

			foreach (var prop in allProperties)
			{
				VxFormGroup.Add(prop.Name, rootGroup, modelInstance, options, tableConfig);
			}

			return rootGroup;
		}

		internal static void Add(string fieldIdentifier, VxFormGroup group, object modelInstance, VxFormLayoutOptions options, TableConfig tableConfig)
		{
			// TODO: EXPANDO switch
			var prop = modelInstance.GetType().GetProperty(fieldIdentifier);
			var layoutAttr = prop.GetCustomAttribute<VxFormElementLayoutAttribute>();
			var allRowLayoutAttributes = VxHelpers.GetAllAttributes<VxFormRowLayoutAttribute>(prop.DeclaringType);


			// If no attribute is found use the name of the property
			if (layoutAttr == null)
				layoutAttr = new VxFormElementLayoutAttribute()
				{
					Label = GetLabel(fieldIdentifier, modelInstance)
				};

			PatchLayoutWithBuiltInAttributes(layoutAttr, prop);


			// Check if row already exists
			var foundRow = group.Rows.Find(value => value.Id == layoutAttr.RowId.ToString());

			if (foundRow == null)
			{
				foundRow = VxFormRowLayout.Create(layoutAttr, allRowLayoutAttributes.Find(x => x.Id == layoutAttr.RowId), options);
				group.Rows.Add(foundRow); ;
			}

			var formColumn = VxFormElementDefinition.Create(fieldIdentifier, layoutAttr, modelInstance, options, tableConfig);
			VxFormRowLayout.AddColumn(foundRow, formColumn, options);

			// WHen there is a VxFormRowLayout found use the name if specified, this also sets the row to combined labels
			if (options.LabelOrientation == LabelOrientation.LEFT && foundRow.RowLayoutAttribute?.Label == null)
				foundRow.Label = string.Join(", ", foundRow.Columns.ConvertAll(x => x.RenderOptions.Label));

		}
		/// <summary>
		/// Get the values of built-in attributes like <see cref="DisplayAttribute"/> and patch it to a <see cref="VxFormLayoutAttribute"/>
		/// </summary>
		/// <param name="layoutAttr">The attribute to patch</param>
		/// <param name="prop">Property for reflection purpouses</param>
		private static void PatchLayoutWithBuiltInAttributes(VxFormElementLayoutAttribute layoutAttr, PropertyInfo prop)
		{
			var displayAttribute = prop
				   .GetCustomAttributes(typeof(DisplayAttribute), false)
				   .FirstOrDefault() as DisplayAttribute;

			if (displayAttribute != null)
			{
				layoutAttr.Label = displayAttribute.GetName();
				layoutAttr.Order = displayAttribute.GetOrder().GetValueOrDefault();
			}
		}

		private static string GetLabel(string fieldIdentifier, object modelInstance)
		{
			return Regex.Replace(fieldIdentifier, "([a-z])([A-Z])", "$1 $2");
		}

		internal static VxFormGroup Create()
		{
			return new VxFormGroup();
		}
	}
}

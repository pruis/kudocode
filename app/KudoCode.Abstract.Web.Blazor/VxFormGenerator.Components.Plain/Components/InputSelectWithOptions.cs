using KudoCode.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using VxFormGenerator.Components.Plain.Models;
using VxFormGenerator.Core;

namespace VxFormGenerator.Form.Components.Plain
{
	public class InputSelectWithOptions<TValue> : RadzenDropDown<TValue>, IRenderChildren
	{
		private bool isLoaded = false;
		public static Type TypeOfChildToRender => typeof(InputSelectOption<string>);

		public static void RenderChildren(RenderTreeBuilder builder, int index, object dataContext,
			string fieldIdentifier)
		{

			var selectedValue = dataContext.GetType().GetProperty(fieldIdentifier).GetValue(dataContext);

			builder.AddAttribute(index + 2, "TextProperty", "Value");
			builder.AddAttribute(index + 3, "bind-Value", selectedValue);
			builder.AddAttribute(index + 4, "TValue", "string");

			builder.AddAttribute(index + 5, "Data",
				//new RenderFragment(_builder =>
				//{

				//// check if the type of the propery is an Enum
				//if (typeof(TValue).IsEnum)
				//	Enum(_builder, dataContext);
				//if (typeof(TValue).FullName.Contains(typeof(VxLookupList).Name))
				//	VxLookup(_builder, dataContext, fieldIdentifier);
				//}
				new List<VxLookup>() { new VxLookup(1, "Option A"), new VxLookup(2, "Option B") }
				 );
		}

		private static void Enum(RenderTreeBuilder _builder, object dataContext)
		{

			// when type is a enum present them as an <option> element 
			// by leveraging the component InputSelectOption
			var values = typeof(TValue).GetEnumValues();


			foreach (var val in values)
			{
				var value = VxSelectItem.ToSelectItem(val as Enum);

				//  Open the InputSelectOption component
				_builder.OpenComponent(0, TypeOfChildToRender);

				// Set the value of the enum as a value and key parameter
				_builder.AddAttribute(1, nameof(InputSelectOption<string>.Value), value.Label);
				_builder.AddAttribute(2, nameof(InputSelectOption<string>.Key), value.Key);

				// Close the component
				_builder.CloseComponent();
			}
		}
		private static void VxLookup(RenderTreeBuilder _builder, object dataContext, string fieldIdentifier)
		{
			// when type is a enum present them as an <option> element 
			// by leveraging the component InputSelectOption
			var values = new List<VxLookup>();
			var dropdownProp = dataContext.GetType().GetProperty(fieldIdentifier).GetValue(dataContext);
			if (dropdownProp == null)
				values.Add(new VxLookup(0, "not selected"));
			else
				values = (List<VxLookup>)dropdownProp.GetType().GetProperty("List").GetValue(dropdownProp);

			values.Add(new VxLookup(1, "Option A"));
			values.Add(new VxLookup(2, "Option B"));

			//if (values.Count > 0)
			foreach (var val in values)
			{
				var value = new VxSelectItem(val.Id, val.Value);

				//  Open the InputSelectOption component
				_builder.OpenComponent(0, TypeOfChildToRender);

				// Set the value of the enum as a value and key parameter
				_builder.AddAttribute(1, nameof(InputSelectOption<string>.Value), value.Label);
				_builder.AddAttribute(2, nameof(InputSelectOption<string>.Key), value.Key);

				// Close the component
				_builder.CloseComponent();
			}

		}


	}
}


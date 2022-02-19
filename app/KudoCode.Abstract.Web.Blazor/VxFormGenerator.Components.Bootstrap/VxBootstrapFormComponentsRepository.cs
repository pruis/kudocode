using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using VxFormGenerator.Form.Components.Bootstrap;
using VxFormGenerator.Models;
using VxFormGenerator.Core.Repository;
using VxFormGenerator.Core;
using VxFormGenerator.Form.Components.Plain;
using KudoCode.Contracts;
using Radzen;

namespace VxFormGenerator.Repository.Bootstrap
{
	public class VxBootstrapRepository : FormGeneratorComponentModelBasedRepository
	{
		public VxBootstrapRepository()
		{

			_ComponentDict = new Dictionary<Type, Type>()
				  {
					{ typeof(string),          typeof(Radzen.Blazor.RadzenTextBox) },
					{ typeof(DateTime),        typeof(RadzenDateTime<>) },
					{ typeof(bool),            typeof(Radzen.Blazor.RadzenCheckBox<>) },
					{ typeof(Enum),            typeof(BootstrapInputSelectWithOptions<>) },
					{ typeof(VxLookup),            typeof(RadzenBootstrapInputSelectWithOptions<>) },
					{ typeof(ValueReferences), typeof(BootstrapInputCheckboxMultiple<>) },
					{ typeof(decimal),         typeof(InputNumber<>) },
					{ typeof(int),             typeof(VxInputNumber) },
					{ typeof(VxColor),         typeof(InputColor) }
				  };

			_DefaultComponent = null;

		}

	}

	
}

using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using KudoCode.Abstract.Web.Blazor;
using KudoCode.Abstract.Web.Blazor;
using KudoCode.Abstract.Web.Blazor.Repository;
using KudoCode.Abstract.Web.Blazor;
using KudoCode.Abstract.Web.Blazor;
using KudoCode.Contracts;
using Radzen;
using Radzen.Blazor;

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
					{ typeof(DateTimeOffset),        typeof(RadzenDateTime<>) },
					{ typeof(bool),            typeof(Radzen.Blazor.RadzenCheckBox<>) },
					{ typeof(Enum),            typeof(BootstrapInputSelectWithOptions<>) },
					{ typeof(VxTextArea),            typeof(BootstrapVxRadzenTextArea) },
					{ typeof(VxLookup),            typeof(RadzenBootstrapInputSelectWithOptions<>) },
					{ typeof(VxDbLookup),            typeof(BootstrapInputSelectDbLookup<>) },
					{ typeof(VxUpload),            typeof(BootstrapVxRadzenUpload) },
					{ typeof(ValueReferences), typeof(BootstrapInputCheckboxMultiple<>) },
					{ typeof(decimal),         typeof(InputNumber<>) },
					{ typeof(int),             typeof(VxInputNumber) },
					{ typeof(VxColor),         typeof(InputColor) }
				  };

			_DefaultComponent = null;

		}

	}

	
}

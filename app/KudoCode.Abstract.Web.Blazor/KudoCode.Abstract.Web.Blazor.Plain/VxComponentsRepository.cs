using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using KudoCode.Abstract.Web.Blazor;
using KudoCode.Abstract.Web.Blazor;
using KudoCode.Abstract.Web.Blazor;
using KudoCode.Abstract.Web.Blazor.Repository;
using KudoCode.Contracts;

namespace VxFormGenerator.Repository.Plain
{
	public class VxComponentsRepository : FormGeneratorComponentModelBasedRepository
	{
		public VxComponentsRepository()
		{

			_ComponentDict = new Dictionary<Type, Type>()
				  {
						{typeof(string), typeof(VxInputText) },
						{typeof(DateTime), typeof(InputDate<>) },
						{typeof(int), typeof(InputNumber<>) },
						{typeof(bool), typeof(VxInputCheckbox) },
						{typeof(Enum), typeof(InputSelectWithOptions<>) },
						{typeof(ValueReferences), typeof(InputCheckboxMultiple<>) },
						{typeof(decimal), typeof(InputNumber<>) },
				{ typeof(VxLookupList),  typeof(InputSelectWithOptions<>) },

						{typeof(VxColor), typeof(InputColor) }
				  };
			_DefaultComponent = null;


		}

	}
}

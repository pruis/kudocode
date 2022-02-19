using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using VxFormGenerator.Core;

namespace VxFormGenerator.Form.Components.Plain
{

    //public class VxInputNumber : InputTextBase<int>
    //{ }


    public class VxInputNumber : VxInputBase<int>, IDisposable
       {
           [Parameter] public string Label { get; set; }
           [Parameter] public string LabelCss { get; set; }
           [Parameter] public string ContainerCss { get; set; }

           protected override void BuildRenderTree(RenderTreeBuilder builder)
           {
               var index = 0;

               builder.OpenElement(index, "div");
            builder.AddAttribute(index++, "class", ContainerCss);
               builder.AddContent(index++, new RenderFragment(builder =>
               {
                   var index2 = 0;
                   builder.OpenElement(index2++, "input");
                   builder.AddMultipleAttributes(index2++, AdditionalAttributes);
                   builder.AddAttribute(index2++, "type", "text");
                   builder.AddAttribute(index2++, "class", CssClass);
                   builder.AddAttribute(index2++, "id", Id);
                   //builder.AddAttribute(index2++, "checked", BindConverter.FormatValue(CurrentValue));
                   builder.AddAttribute(index2++, "value", BindConverter.FormatValue(CurrentValue));
                   builder.AddAttribute(index2++, "onchange", EventCallback.Factory.CreateBinder<int>(this, __value => CurrentValue = __value, CurrentValue));
                   builder.CloseElement();

                   //builder.OpenElement(index2++, "label");
                   //builder.AddAttribute(index2++, "class", LabelCss);
                   //builder.AddAttribute(index2++, "for", Id);
                   //builder.AddContent(index2++, Label);
                   //builder.CloseElement();
               }));

               builder.CloseElement();
           }

		protected override bool TryParseValueFromString(string value, [MaybeNullWhen(false)] out int result, [NotNullWhen(false)] out string validationErrorMessage)
		{
			throw new NotImplementedException();
		}
	}

}

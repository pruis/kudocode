using Microsoft.AspNetCore.Components.Forms;
using System;
using VxFormGenerator.Form;

namespace KudoCode.Abstract.Web.Blazor
{
    public class VxFormOptions : IFormGeneratorOptions
    {
        public Type FormElementComponent { get; set; }
        public FieldCssClassProvider FieldCssClassProvider { get; set; }
        public Type FormGroupElement { get; set; }

        public VxFormOptions()
        {
            FormElementComponent = typeof(FormElement<>);
            FormGroupElement = typeof(VxFormGroup);
        }
    }
}

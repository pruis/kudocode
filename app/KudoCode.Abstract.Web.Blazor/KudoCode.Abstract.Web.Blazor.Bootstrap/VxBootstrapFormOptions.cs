using Microsoft.AspNetCore.Components.Forms;
using System;
using KudoCode.Abstract.Web.Blazor;
using VxFormGenerator.Form;
using VxFormGenerator.Render.Bootstrap;
using KudoCode.Abstract.Web.Blazor;

namespace VxFormGenerator.Settings.Bootstrap
{
    public class VxBootstrapFormOptions : IFormGeneratorOptions
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Type FormElementComponent { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public FieldCssClassProvider FieldCssClassProvider { get; set; }
        public Type FormGroupElement { get; set; }
        public VxBootstrapFormOptions()
        {
            FormElementComponent = typeof(BootstrapFormElement<>);
            FormGroupElement = typeof(VxFormGroup);
            FieldCssClassProvider = new VxBootstrapFormCssClassProvider();
        }
    }
}

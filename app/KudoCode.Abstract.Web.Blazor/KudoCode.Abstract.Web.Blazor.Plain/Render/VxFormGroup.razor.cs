using KudoCode.Abstract.Web.Blazor;
using Microsoft.AspNetCore.Components;

namespace KudoCode.Abstract.Web.Blazor
{
    public class VxFormGroupComponent : OwningComponentBase
    {
        [Parameter] public Layout.VxFormGroup FormGroupDefinition { get; set; }

        [CascadingParameter] public VxFormLayoutOptions FormLayoutOptions { get; set; }
    }
}


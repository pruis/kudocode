using Microsoft.AspNetCore.Components;

namespace KudoCode.Abstract.Web.Blazor
{
    public class VxFormGroupBase : OwningComponentBase
    {
        [Parameter] public Layout.VxFormGroup FormGroupDefinition { get; set; }
    }
}


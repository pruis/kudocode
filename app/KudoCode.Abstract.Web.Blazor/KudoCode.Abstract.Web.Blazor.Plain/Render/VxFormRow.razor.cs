using Microsoft.AspNetCore.Components;

namespace KudoCode.Abstract.Web.Blazor
{
    public class VxFormRowComponent : OwningComponentBase
    {
        [Parameter] public VxFormRowLayout FormRowDefinition { get; set; }
        [CascadingParameter] public VxFormLayoutOptions FormLayoutOptions { get; set; }

    }
}


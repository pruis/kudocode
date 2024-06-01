using Microsoft.AspNetCore.Components;

namespace KudoCode.Abstract.Web.Blazor
{
    public interface IKudoCodeUiComponent
    {
        [Parameter] string Id { get; set; }
        [Parameter] int[] ColSize { get; set; }
        string ColClass(int index);
    };
}
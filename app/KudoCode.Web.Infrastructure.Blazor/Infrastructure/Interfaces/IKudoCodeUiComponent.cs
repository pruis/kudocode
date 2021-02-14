using Microsoft.AspNetCore.Components;

namespace KudoCode.Web.Infrastructure.Blazor.Infrastructure.Interfaces
{
    public interface IKudoCodeUiComponent
    {
        [Parameter] string Id { get; set; }
        [Parameter] int[] ColSize { get; set; }
        string ColClass(int index);
    };
}
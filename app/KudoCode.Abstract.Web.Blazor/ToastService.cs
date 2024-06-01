using KudoCode.Contracts;
using KudoCode.Contracts.Web;
using Microsoft.JSInterop;
using System.Linq;

namespace KudoCode.Abstract.Web.Blazor
{
    public class ToastService : IToastService
    {
        private IJSRuntime _jsRuntime;

        public ToastService(IJSRuntime jsRuntime)
        {
            _jsRuntime  = jsRuntime;
        }

        public void ToastMessage(params MessageDto[] messages)
        {
            foreach (var x in messages.Where(a => a.Type == MessageDtoType.Error))
                _jsRuntime.InvokeAsync<string>($"Toast.error", $"{x.Message}", $"{x.Key}: error");

            foreach (var x in messages.Where(a => a.Type == MessageDtoType.Success))
                _jsRuntime.InvokeAsync<string>($"Toast.success", $"{x.Message}", $"{x.Key}: success");

            foreach (var x in messages.Where(a => a.Type == MessageDtoType.Warning))
                _jsRuntime.InvokeAsync<string>($"Toast.warning", $"{x.Message}", $"{x.Key}: warning");

            foreach (var x in messages.Where(a => a.Type == MessageDtoType.Information))
                _jsRuntime.InvokeAsync<string>($"Toast.information", $"{x.Message}", $"{x.Key}: information");
        }
    }
}

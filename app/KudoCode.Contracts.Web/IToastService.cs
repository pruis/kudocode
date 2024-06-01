using Microsoft.JSInterop;

namespace KudoCode.Contracts.Web
{
    public interface IToastService
    {
        void ToastMessage(params MessageDto[] messages);
    }
}
using KudoCode.Contracts;
using System.Collections.Generic;

namespace KudoCode.Contracts.Web
{
	public interface IWebResponseDto<T> : IMessagesContext where T : new()
    {
        T Result { get; set; }
        List<MessageDto> Errors { get; set; }
        Configuration Configuration { get; set; }

        void AddError(string key, string[] values = null);
        void RaiseEvent(object @event);
        void SetRedirect(string action, string actionValue, string title);
        bool HasErrors();
    }
}
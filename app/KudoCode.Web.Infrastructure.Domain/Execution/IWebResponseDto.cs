using System;
using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;

namespace KudoCode.Web.Infrastructure.Domain.Execution
{
    public interface IWebResponseDto<T> : IContextMessages where T : new()
    {
        T Result { get; set; }
        List<MessageDto> Messages { get; set; }
        List<MessageDto> Errors { get; set; }
        Configuration Configuration { get; set; }

        void AddError(string key, string[] values = null);
        void RaiseEvent(object @event);
        void SetRedirect(string action, string actionValue, string title);
        bool HasErrors();
    }
}
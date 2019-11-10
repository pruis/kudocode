using System;
using System.Collections.Generic;
using System.Linq;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;

namespace KudoCode.Web.Infrastructure.Domain.Execution
{
    public class WebResponseDto<T> : IWebResponseDto<T> where T : new()
    {
        public WebResponseDto()
        {
            Messages = new List<MessageDto>();
            Errors = new List<MessageDto>();
            Result = new T();
        }

        public void SetRedirect(string action, string actionValue, string title)
        {
            Redirect = new ResponseRedirect(actionValue, action, title);
        }

        public bool HasErrors()
        {
            return Messages.Any(a=>a.Type == MessageDtoType.Error);
        }


        public T Result { get; set; }
        public List<MessageDto> Messages { get; set; }
        public List<MessageDto> Errors { get; set; }
        public ResponseRedirect Redirect { get; private set; }
        public Configuration Configuration { get; set; }

        public void AddError(string key, string[] values = null)
        {
            //todo : prevent initialization
            var error = new ErrorsCollectionWeb().List.First(a => a.Key == key);
            if (values != null)
                error.Message = string.Format(error.Message, values);
            Messages.Add(error);
        }

        public void RaiseEvent(object @event)
        {
            throw new System.NotImplementedException();
        }

        internal void SetRedirect(string v, object p)
        {
            throw new NotImplementedException();
        }
    }


    public class Configuration
    {
        public string DateFormat { get; set; }
        public string DateTimeFormat { get; set; }
    }

    public class ErrorsCollectionWeb
    {
        public IReadOnlyCollection<MessageDto> List = new List<MessageDto>()
        {
            new MessageDto("EW1", "Internal Error: {0}", MessageDtoType.Error),
            new MessageDto("EW2", "{0}", MessageDtoType.Error),
        };
    }
}
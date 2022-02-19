using System.Collections.Generic;
using System.Linq;

namespace KudoCode.Contracts
{
	public class ApiResponseContextDto<TOut> : IApiResponseContextDto<TOut>
    {
        public ApiResponseContextDto()
        {
            Messages = new List<MessageDto>();
        }

        public ApiResponseContextDto(List<MessageDto> messages)
        {
            Messages = messages;
        }

        public TOut Result { get; set; }
        public List<MessageDto> Messages { get; set; }

        public bool HasErrors()
        {
            return Messages.Any(a => a.Type == MessageDtoType.Error);
        }
    }
}
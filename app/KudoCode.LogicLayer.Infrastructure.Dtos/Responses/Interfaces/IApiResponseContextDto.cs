using System.Collections.Generic;
using System.Linq;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces
{
    public interface IApiResponseContextDto<TOut>
    {
        TOut Result { get; set; }
        List<MessageDto> Messages { get; set; }
    }


    public static class ApiResponseContextDtoExtensions
    {
        public static bool HasErrors<TOut>(this IApiResponseContextDto<TOut> context)
        {
            return context.Messages.Any(a => a.Type == MessageDtoType.Error);
        }
    }
}
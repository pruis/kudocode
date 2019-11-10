using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.Web.Infrastructure.Domain.HttpConnector
{
    public class ApiPostController
    {
        private readonly HttpHandler _httpHandler;

        public ApiPostController(HttpHandler httpHandler)
        {
            _httpHandler = httpHandler;
        }

        public ApiPostHandler<TRequestDto, TResponseDto> Create<TRequestDto, TResponseDto>()
            where TRequestDto : IApiRequestDto
        {
            return new ApiPostHandler<TRequestDto, TResponseDto>(_httpHandler);
        }
    }
}
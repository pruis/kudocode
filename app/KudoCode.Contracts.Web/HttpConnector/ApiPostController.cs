using KudoCode.Contracts;

namespace KudoCode.Contracts.Web
{
	public class ApiPostController
	{
		private readonly HttpHandler _httpHandler;

		public ApiPostController(HttpHandler httpHandler)
		{
			_httpHandler = httpHandler;
		}

		public ApiPostHandler<TRequestDto, TResponseDto> Create<TRequestDto, TResponseDto>()
			where TRequestDto : IApiRequestDto => new ApiPostHandler<TRequestDto, TResponseDto>(_httpHandler);

		public ApiPostHandlerAsync<TRequestDto, TResponseDto> CreateAsync<TRequestDto, TResponseDto>()
			//where TRequestDto : IApiRequestDto
		{
			return new ApiPostHandlerAsync<TRequestDto, TResponseDto>(_httpHandler);
		}
	}
}
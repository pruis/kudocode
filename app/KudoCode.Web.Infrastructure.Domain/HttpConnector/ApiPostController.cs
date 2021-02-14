using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;
using Tescodesign.Core.Communication.Api;

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
			where TRequestDto : IApiRequestDto => new ApiPostHandler<TRequestDto, TResponseDto>(_httpHandler);

		public ApiPostHandlerAsync<TRequestDto, TResponseDto> CreateAsync<TRequestDto, TResponseDto>()
			where TRequestDto : IApiRequestDto => new ApiPostHandlerAsync<TRequestDto, TResponseDto>(_httpHandler);
	}
}
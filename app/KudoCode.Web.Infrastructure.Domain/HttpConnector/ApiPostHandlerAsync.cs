using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;
using KudoCode.Web.Infrastructure.Domain.HttpConnector;
using System;
using System.Threading.Tasks;

namespace Tescodesign.Core.Communication.Api
{
	public class ApiPostHandlerAsync<TRequestDto, TResponseDto> where TRequestDto : IApiRequestDto
	{
		private readonly HttpHandler _httpHandler;
		private Action<IApiResponseContextDto<TResponseDto>> _onFail;
		private Action<IApiResponseContextDto<TResponseDto>> _onSuccess;
		private Action<IApiResponseContextDto<TResponseDto>> _onComplete;

		public ApiPostHandlerAsync(HttpHandler httpHandler)
		{
			_httpHandler = httpHandler ?? throw new ArgumentNullException(nameof(httpHandler));
		}

		public async Task<IApiResponseContextDto<TResponseDto>> PostAsync(TRequestDto dto)
		{
			IApiResponseContextDto<TResponseDto> result = null;
			try
			{
				result = await _httpHandler.PostAsync<TRequestDto, TResponseDto>(dto);

				if (result == null || result.HasErrors())
				{
					_onFail?.Invoke(result);
				}
				else
				{
					_onSuccess?.Invoke(result);
				}

				return result;

			}
			catch (Exception e)
			{
				if (result == null)
				{
					result = new ApiResponseContextDto<TResponseDto>();
				}

				Console.WriteLine(e);
				result?.Messages.Add(new MessageDto("CE1", "Unable to connect to API", MessageDtoType.Error));
				throw;

			}
			finally
			{
				if (result == null || result.HasErrors())
				{
					_onFail?.Invoke(result);
				}
				else
				{
					_onSuccess?.Invoke(result);
				}
				_onComplete?.Invoke(result);

			}
		}

		public ApiPostHandlerAsync<TRequestDto, TResponseDto> SetOnSuccess(
			Action<IApiResponseContextDto<TResponseDto>> onSuccess)
		{
			_onSuccess = onSuccess;
			return this;
		}

		public ApiPostHandlerAsync<TRequestDto, TResponseDto> SetOnComplete(
			Action<IApiResponseContextDto<TResponseDto>> onComplete)
		{
			_onComplete = onComplete;
			return this;
		}


		public ApiPostHandlerAsync<TRequestDto, TResponseDto> SetOnFail(
			Action<IApiResponseContextDto<TResponseDto>> onFail)
		{
			_onFail = onFail;
			return this;
		}
	}
}

using KudoCode.Contracts;
using System;
using System.Threading.Tasks;

namespace KudoCode.Contracts.Web
{
	public class ApiPostHandlerAsync<TRequestDto, TResponseDto> : IApiPostHandlerAsync<TRequestDto, TResponseDto> //where TRequestDto : IApiRequestDto
	{
		private readonly HttpHandler _httpHandler;
		private Action<IApiResponseContextDto<TResponseDto>> _onFail;
		private Action<IApiResponseContextDto<TResponseDto>> _onSuccess;
		private Action<IApiResponseContextDto<TResponseDto>> _onComplete;
		private object _uiContext;

		public ApiPostHandlerAsync(HttpHandler httpHandler)
		{
			_httpHandler = httpHandler ?? throw new ArgumentNullException(nameof(httpHandler));
		}

		public async Task<IApiResponseContextDto<TResponseDto>> PostAsync(TRequestDto dto, string serviceDestination = "")
		{
			IApiResponseContextDto<TResponseDto> result = null;
			try
			{
				result = await _httpHandler.PostAsync<TRequestDto, TResponseDto>(dto, serviceDestination);

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
					//if (_uiContext != null)
					{
						_uiContext = result.Result;
					}
				}
				_onComplete?.Invoke(result);

			}
		}


		public ApiPostHandlerAsync<TRequestDto, TResponseDto> SetUiContext(object uiContext)
		{
			_uiContext = uiContext;
			return this;
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

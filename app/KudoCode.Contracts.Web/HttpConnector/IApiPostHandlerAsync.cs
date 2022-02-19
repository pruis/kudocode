using KudoCode.Contracts;
using System;
using System.Threading.Tasks;

namespace KudoCode.Contracts.Web
{
	public interface IApiPostHandlerAsync<TRequestDto, TResponseDto> //where TRequestDto : IApiRequestDto
	{
		Task<IApiResponseContextDto<TResponseDto>> PostAsync(TRequestDto dto, string serviceDestination = "");
		ApiPostHandlerAsync<TRequestDto, TResponseDto> SetOnComplete(Action<IApiResponseContextDto<TResponseDto>> onComplete);
		ApiPostHandlerAsync<TRequestDto, TResponseDto> SetOnFail(Action<IApiResponseContextDto<TResponseDto>> onFail);
		ApiPostHandlerAsync<TRequestDto, TResponseDto> SetOnSuccess(Action<IApiResponseContextDto<TResponseDto>> onSuccess);
	}
}
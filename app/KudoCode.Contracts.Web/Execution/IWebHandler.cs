namespace KudoCode.Contracts.Web
{
	public interface IWebHandler<TDto, TReturn> where TReturn : new()
	{
		IWebResponseDto<TReturn> Handle(TDto dto, IWebResponseDto<TReturn> webResponseDto);
	}
}
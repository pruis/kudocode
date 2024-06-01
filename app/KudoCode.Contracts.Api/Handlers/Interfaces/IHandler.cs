namespace KudoCode.Contracts.Api
{

	public interface IHandler<TRequestDto, TOut>
	{
		TOut Handle(TRequestDto request);
	}

}
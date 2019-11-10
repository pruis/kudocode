namespace KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces
{

	public interface IHandler<TRequestDto, TOut>
	{
		TOut Handle(TRequestDto request);
	}

}
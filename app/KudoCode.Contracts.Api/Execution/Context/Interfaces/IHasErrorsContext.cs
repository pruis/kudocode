namespace KudoCode.Contracts.Api
{
	public interface IHasErrorsContext<TOut>
	{
		bool HasErrors();
	}
}
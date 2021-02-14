namespace KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces
{
	public interface IHasErrorsContext<TOut>
	{
		bool HasErrors();
	}
}
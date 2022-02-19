
namespace KudoCode.Contracts.Api
{
	public interface IExecutionPipelineFilter<TRequestDto, TOut>
	{
		IExecutionPipelineFilter<TRequestDto, TOut> Participate(TRequestDto requestDto);
	}
}
using Autofac;

namespace KudoCode.LogicLayer.Infrastructure.Execution.Participants.Interfaces
{

	public interface IExecutionPipelineFilter<TRequestDto,TOut>
	{
		IExecutionPipelineFilter<TRequestDto, TOut> Participate(TRequestDto requestDto);
	}
}
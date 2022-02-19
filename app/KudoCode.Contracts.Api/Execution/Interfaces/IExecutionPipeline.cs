using KudoCode.Contracts;

namespace KudoCode.Contracts.Api
{
	public interface IExecutionPipelineHandlers : IExecutionPipeline
	{
	}

	public interface IExecutionPipeline
	{
		IApiResponseContextDto<TOut> Execute<TRequestDto, TOut>(TRequestDto dto, string scopeName = "", string token = "")
			where TRequestDto : IApiRequestDto;
	}

	public interface ISecondaryExecutionPipeline : IExecutionPipeline
	{
	}

}
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Execution.Interfaces
{
    public interface IExecutionPipelineHandlers : IExecutionPipeline
    {
    }

    public interface IExecutionPipeline
    {
        IApiResponseContextDto<TOut> Execute<TRequestDto, TOut>(TRequestDto dto, string token = "")
            where TRequestDto : IApiRequestDto;
    }

    public interface ISecondaryExecutionPipeline
    {
        IApiResponseContextDto<TOut> Execute<TRequestDto, TOut>(TRequestDto dto, string token = "")
            where TRequestDto : IApiRequestDto;
    }
}
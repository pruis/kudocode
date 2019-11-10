using System.Threading.Tasks;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests;
using KudoCode.LogicLayer.Infrastructure.Execution.PipeLines;

namespace KudoCode.LogicLayer.Infrastructure
{
    public class ApiControllerRequestManager
    {
        private readonly ExecutionPipeline _executionPipeline;
        public ApiControllerRequestManager(ExecutionPipeline executionPipeline)
        {
            _executionPipeline = executionPipeline;
        }

        public async Task<object> Execute(ApiControllerRequestDto dto)
        {
            var method = _executionPipeline
                .GetType()
                .GetMethod("Execute")
                .MakeGenericMethod(dto.Request.GetType(),
                    StaticHelpers.GetBusinessDtoType(dto.ResponseType));

            return await Task.Run(
                () => method.Invoke(_executionPipeline,
                    new[] {(object) dto.Request, dto.AuthenticationToken})
            );
        }
    }
}
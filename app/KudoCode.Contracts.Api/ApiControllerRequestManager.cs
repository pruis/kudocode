using KudoCode.Helpers;
using KudoCode.Contracts;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace KudoCode.Contracts.Api
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
				.MakeGenericMethod(StaticHelpers.GetBusinessDtoType(dto.RequestType),
					StaticHelpers.GetBusinessDtoType(dto.ResponseType));

			var request = JsonConvert.DeserializeObject(dto.Request,
				StaticHelpers.GetBusinessDtoType(dto.RequestType));

			return await Task.Run(
				() => method.Invoke(_executionPipeline,
					new[] { (object)request,"", dto.AuthenticationToken })
			);
		}
	}
}
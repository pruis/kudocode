using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure
{
	public static class ApiResponseContextExtensions
	{
		public static IApiResponseContextDto<TOut> AttachResult<TOut>(this IApiResponseContextDto<TOut> response, IContextMessages context)
		{
			context.Messages.AddRange(response.Messages);
			return response;
		}
	}
}
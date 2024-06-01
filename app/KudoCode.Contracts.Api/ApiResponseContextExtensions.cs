using KudoCode.Contracts;

namespace KudoCode.Contracts.Api
{
	public static class ApiResponseContextExtensions
	{
		public static IApiResponseContextDto<TOut> AttachResult<TOut>(this IApiResponseContextDto<TOut> response, IMessagesContext context)
		{
			context.Messages.AddRange(response.Messages);
			return response;
		}
	}
}
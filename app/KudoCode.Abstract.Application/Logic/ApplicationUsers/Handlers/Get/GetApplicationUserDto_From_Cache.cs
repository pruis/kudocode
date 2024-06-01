using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;

namespace KudoCode.Abstract.Application
{
	public class GetApplicationUserDto_From_Cache :
		QueryHandler<GetApplicationUserRequest, ApplicationUser, GetApplicationUserResponse>, IRedisCacheQueryHandler
	{
		public GetApplicationUserDto_From_Cache(IMapper mapper, IReadOnlyRepository repository,
			IComponentContext scope, IWorkerContext<GetApplicationUserResponse> context) : base(mapper, repository, scope,
			context)
		{
		}
		protected override void Execute()
		{
			// user context was not found using IRedisCacheQueryHandler
			Context.AddMessage("E3", "User session not found");
		}

		public string RedisKey() => $"ApplicationUserContext_{Request.Email}";

	}
}
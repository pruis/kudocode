using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace KudoCode.Abstract.Application
{
	public class GetApplicationUserDtoWorkerHandler :
		QueryHandler<GetApplicationUserDto, ApplicationUser, ApplicationUserDto>, IRedisCacheQueryHandler
	{
		public GetApplicationUserDtoWorkerHandler(IMapper mapper, IReadOnlyRepository repository,
			IComponentContext scope, IWorkerContext<ApplicationUserDto> context) : base(mapper, repository, scope,
			context)
		{
		}

		protected override void GetEntity()
		{
			Entity = Repository.GetOne<ApplicationUser>(a => a.Email.ToLower().Equals(Request.Email.ToLower()),
				src => src.Include(a => a.EntityOrganizations).ThenInclude(a => a.EntityOrganization)
				.Include(a => a.AuthorizationGroups).ThenInclude(a => a.AuthorizationGroup)
				.Include(a => a.AuthorizationRole)
				);
		}

		protected override void ValidateEntity()
		{
			if (Entity == null)
				Context.AddMessage("E4");
		}

		protected override void Execute()
		{
			Context.Result = Mapper.Map<ApplicationUserDto>(Entity);
		}

		public string RedisKey() => $"ApplicationUserContext_{Request.Email}";

	}
}
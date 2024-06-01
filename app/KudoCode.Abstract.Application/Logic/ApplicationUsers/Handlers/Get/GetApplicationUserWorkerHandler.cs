using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace KudoCode.Abstract.Application
{
    public class GetApplicationUserWorkerHandler :
        QueryHandler<GetApplicationUserRequest, ApplicationUser, GetApplicationUserResponse>, IRedisCacheQueryHandler
    {
        public GetApplicationUserWorkerHandler(IMapper mapper, IReadOnlyRepository repository,
            IComponentContext scope, IWorkerContext<GetApplicationUserResponse> context) : base(mapper, repository, scope,
            context)
        {
        }

        protected override void GetEntity()
        {

            if (Request.Id > 0)
                Entity = Repository.GetOne<ApplicationUser>(a => a.Id == Request.Id,
                    src => src
                    .Include(a => a.EntityOrganizations).ThenInclude(a => a.EntityOrganization)
                    .Include(a => a.AuthorizationGroups).ThenInclude(a => a.AuthorizationGroup)
                    .Include(a => a.AuthorizationRole)
                    .Include(a => a.ActiveEntityOrganization)
                    );

            if (Entity == null && !string.IsNullOrEmpty(Request.Email))
                Entity = Repository.GetOne<ApplicationUser>(a => a.Email.ToLower().Equals(Request.Email.ToLower()),
                    src => src
                    .Include(a => a.EntityOrganizations).ThenInclude(a => a.EntityOrganization)
                    .Include(a => a.AuthorizationGroups).ThenInclude(a => a.AuthorizationGroup)
                    .Include(a => a.AuthorizationRole)
                    .Include(a => a.ActiveEntityOrganization)
                    );
        }

        protected override void ValidateEntity()
        {
            if (Entity == null)
                Context.AddMessage("E4", $"user {Request.Email}");
        }

        protected override void Execute()
        {
            Context.Result = Mapper.Map<GetApplicationUserResponse>(Entity);
        }

        public string RedisKey() => $"ApplicationUserContext_{Request.Email}";

    }
}
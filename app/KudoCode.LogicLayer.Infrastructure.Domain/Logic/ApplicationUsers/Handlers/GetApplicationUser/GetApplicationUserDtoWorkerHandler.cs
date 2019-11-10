using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Entities;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Handlers.GetApplicationUser
{
    public class GetApplicationUserDtoWorkerHandler :
        QueryHandler<GetApplicationUserDto, ApplicationUser, ApplicationUserDto>
    {
        public GetApplicationUserDtoWorkerHandler(IMapper mapper, IReadOnlyRepository repository,
            IComponentContext scope, IWorkerContext<ApplicationUserDto> context) : base(mapper, repository, scope,
            context)
        {
        }

        protected override void Execute()
        {
            Context.Result = Mapper.Map<ApplicationUserDto>(Entity);
        }

        protected override void GetEntity()
        {
            Entity = Repository.GetOne<ApplicationUser>(a => a.Email.ToLower().Equals(Request.Email.ToLower()),
                @"EntityOrganizations.EntityOrganization," +
                "AuthorizationGroups.AuthorizationGroup," +
                "AuthorizationRole");
        }

        protected override void ValidateEntity()
        {
            if (Entity == null)
                Context.AddMessage("E4");
        }
    }
}
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Entities;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                src => src.Include(a => a.EntityOrganizations).ThenInclude(a=>a.EntityOrganization)
                .Include(a=>a.AuthorizationGroups).ThenInclude(a=>a.AuthorizationGroup)
                .Include(a=>a.AuthorizationRole)
                );
        }

        protected override void ValidateEntity()
        {
            if (Entity == null)
                Context.AddMessage("E4");
        }
    }
}
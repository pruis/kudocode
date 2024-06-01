using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KudoCode.ApplicationUsersService.Domain
{
    public class ListApplicationUserWorkerHandler : QueryHandler<ListApplicationUserRequest,
        List<ApplicationUser>, ListApplicationUserResponse>
    {
        public ListApplicationUserWorkerHandler(
            IMapper mapper,
            IRepository repository,
            ILifetimeScope scope,
            IWorkerContext<ListApplicationUserResponse> context)
            : base(mapper, repository, scope, context)
        {
        }

        protected override void GetEntity()
        {
            Entity = Repository.GetIQueryable<ApplicationUser>(null, a => a.Include(a => a.ActiveEntityOrganization)).ToList();
        }


        protected override void Execute()
        {
            Context.Result = new ListApplicationUserResponse() { List = Mapper.Map<List<ApplicationUserResponse>>(Entity) };
        }
    }
}

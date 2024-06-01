using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.Contracts;
using System.Linq;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.Create
{
	public class CreateLeadWorkerHandler : CommandHandler<CreateLeadRequest, Lead, int>
    {
        private readonly IApplicationUserContext _applicationUserContext;

        public CreateLeadWorkerHandler(
            IMapper mapper,
            IRepository repository,
            ILifetimeScope scope,
            IWorkerContext<int> context, IApplicationUserContext applicationUserContext
        ) : base(mapper, repository, scope, context)
        {
            _applicationUserContext = applicationUserContext;
        }

        protected override void GetEntity()
        {
            Entity = new Lead();
            Entity.AgentId = Repository.GetOne<ApplicationUser>(a => a.Id == _applicationUserContext.Id).Id;
        }

        protected override void ValidateEntity()
        {
            var any = Repository.GetIQueryable<LeadPersonalInformation>()
                .Any(a => a.Email.Equals(Request.LeadPersonalInformation.Email.ToLower()));
            if (any)
                Context.AddMessage("E1",
                    $"{Request.LeadPersonalInformation.Email} email already registed");
        }

        protected override void Execute()
        {
            foreach (var groupDto in _applicationUserContext.AuthorizationGroups)
                Entity.AuthorizationGroups.Add(new LeadAuthorizationGroupMap()
                    {Lead = Entity, AuthorizationGroupId = groupDto.Id});


            Entity = Mapper.Map(Request, Entity);
            Repository.Save(Entity);
            Repository.SaveChanges();
            Context.Result = Entity.Id;
        }
    }
}
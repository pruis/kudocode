using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Entities;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Entities.Interface;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos.Interfaces;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Handlers.Create
{
	public class CreateEntityAuditDtoWorkerHandler : CommandHandler<ICreateEntityAuditDto, IEntityAudit, int>
    {
        private ILifetimeScope _scope;

        public CreateEntityAuditDtoWorkerHandler(
            IMapper mapper,
            IRepository repository,
            IWorkerContext<int> context,
            ILifetimeScope scope)
            : base(mapper, repository, scope, context)
        {
            _scope = scope;
        }

        protected override void Execute()
        {
            Entity = _scope.Resolve<IEntityAudit>();
            Mapper.Map(Request, Entity);
            Repository.Save((EntityAudit)Entity);
            Repository.SaveChanges();
            Context.Result = Entity.Id;
        }
    }
}
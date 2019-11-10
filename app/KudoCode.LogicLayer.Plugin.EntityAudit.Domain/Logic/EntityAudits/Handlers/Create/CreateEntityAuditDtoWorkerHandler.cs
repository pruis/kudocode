using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using KudoCode.LogicLayer.Plugin.EntityAudit.Dtos.Interfaces;
using KudoCode.LogicLayer.Plugin.EntityAudit.Domain.Logic.EntityAudits.Entities.Interface;

namespace KudoCode.LogicLayer.Plugin.EntityAudit.Domain.Logic.EntityAudits.Handlers.Create
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
            Repository.Save(Entity);
            Repository.SaveChanges();
            Context.Result = Entity.Id;
        }
    }
}
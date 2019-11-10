using Autofac;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.LogicLayer.Plugin.EntityAudit.UnitTests.Handlers;
using KudoCode.LogicLayer.Plugin.EntityAudit.UnitTests.Objects;
using KudoCode.LogicLayer.Plugin.EntityAudit.UnitTests.Repositories;

namespace KudoCode.LogicLayer.Plugin.EntityAudit.UnitTests.AutofacModules
{
    public class EntityAuditTestAutofac : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StubRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<EntityAuditDefinition>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<TestCommandHandler>().AsImplementedInterfaces().As<IHandler<RequestDto,IWorkerContext<ResponseDto>>>().InstancePerLifetimeScope();
        }
    }
}
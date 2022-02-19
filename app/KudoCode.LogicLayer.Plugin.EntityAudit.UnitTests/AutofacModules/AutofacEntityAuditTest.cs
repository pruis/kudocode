using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Plugin.EntityAudit_.UnitTests.Handlers;
using KudoCode.LogicLayer.Plugin.EntityAudit_.UnitTests.Objects;
using KudoCode.LogicLayer.Plugin.EntityAudit_.UnitTests.Repositories;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.UnitTests.AutofacModules
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
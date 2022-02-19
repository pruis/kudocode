using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Plugin;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Plugin.Factory;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.AutofacModules
{
	public class AutofacEntityAudit : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Entities.EntityAudit>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<EntityAuditFactory>().AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EntityAuditCommandHandlerPlugin<,,>))
                .As(typeof(ICommandHandlerDelegates<,,>))
                .PropertiesAutowired();
        }
    }
}
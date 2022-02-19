using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Plugin.Redis.Domain.Logic.Redis.Plugin;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;

namespace KudoCode.LogicLayer.Plugin.Redis.Domain
{
	public class RedisAutoFac : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DelegateContext>().AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterGeneric(typeof(RedisQueryHandlerPlugin<,,>))
                .As(typeof(IQueryHandlerDelegates<,,>))
                .PropertiesAutowired().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(RedisCommandHandlerPlugin<,,>))
                .As(typeof(ICommandHandlerDelegates<,,>))
                .PropertiesAutowired().InstancePerLifetimeScope();
        }
    }

    public class RedisAutoFac_Testing : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DelegateContext>().AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterGeneric(typeof(RedisQueryHandlerPlugin_Testing<,,>))
                .As(typeof(IQueryHandlerDelegates<,,>))
                .PropertiesAutowired().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(RedisCommandHandlerPlugin_Testing<,,>))
                .As(typeof(ICommandHandlerDelegates<,,>))
                .PropertiesAutowired().InstancePerLifetimeScope();
        }
    }
}
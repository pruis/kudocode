using Autofac;
using KudoCode.Abstract.Application;
using KudoCode.Contracts;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Plugin.Redis.Domain.Logic.Redis.Plugin;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;
namespace KudoCode.LogicLayer.Plugin.Redis.Domain
{
    public class RedisPluginHandlersAutoFac : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

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
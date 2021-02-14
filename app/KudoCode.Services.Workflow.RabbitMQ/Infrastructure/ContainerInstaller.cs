using System;
using Autofac;
using KudoCode.Messaging.RabbitMQ;
using KudoCode.Web.Api.Connector;

namespace Core.Services.Workflow.RabbitMQ.Infrastructure
{
    public static class ContainerInstaller
    {
        public static bool IsBuild { get; private set; }

        public static void Build()
        {
            if (IsBuild)
                return;
            var builder = new ContainerBuilder();

            builder.RegisterType<AggregateEventHandler>()
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterType<EventExecutionPipeLine>().AsSelf().InstancePerDependency();
            builder.RegisterType<Connector>().AsSelf().SingleInstance();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("EventHandler"))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            ApplicationContext.Container = builder.Build();
            IsBuild = true;
        }
    }
}
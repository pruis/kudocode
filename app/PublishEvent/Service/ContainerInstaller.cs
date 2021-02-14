using Autofac;
using KudoCode.Messaging.Infrastructure.Interfaces;
using Core.Services.Workflow.RabbitMQ.Infrastructure;
using IContainer = Autofac.IContainer;

namespace PublishEvent.Service
{
    public static class ContainerInstaller
    {
        public static IContainer BuildContainer()
        {
            //Start building container

            var builder = new ContainerBuilder();

            KudoCode.LogicLayer.Dtos.Constants.EventQueues.Queue.ForEach(source =>
                builder.RegisterType<RabbitMqManager>()
                    .As<IEventManager>()
                    .Named(source, typeof(IEventManager))
                    .WithParameter(new TypedParameter(typeof(string), source))
                    .SingleInstance()
            );
            var container = builder.Build();
            return container;
        }
    }
}
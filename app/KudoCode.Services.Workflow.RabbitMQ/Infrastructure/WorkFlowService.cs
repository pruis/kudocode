using System.Collections.Generic;
using Autofac;
using KudoCode.LogicLayer.Dtos;
using KudoCode.Contracts;
using KudoCode.Contracts;
using KudoCode.Web.Api.Connector;
using KudoCode.Contracts.Api;

namespace Core.Services.Workflow.RabbitMQ.Infrastructure
{
    public class WorkFlowService
    {
        private List<IEventManager> _managers;

        public WorkFlowService()
        {
            _managers = new List<IEventManager>();
        }

        public bool Start()
        {
            ContainerInstaller.Build();
            ApplicationContext.Container
                .Resolve<Connector>()
                .Authentication
                .GetToken(new GetTokenRequest() {Email = "work@flow.com", Password = "1234"});

            foreach (var queue in Constants.EventQueues.Queue)
                _managers.Add(new RabbitMqManager(queue).Listen());

            return true;
        }

        public bool Stop()
        {
            ApplicationContext.Container?.Dispose();
            _managers.ForEach(a => a?.Dispose());
            return true;
        }
    }
}
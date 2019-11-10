using System.Linq;
using KudoCode.LogicLayer.Plugin.EntityAudit.Dtos;
using KudoCode.Messaging.Infrastructure;
using KudoCode.Web.Api.Connector;

namespace Core.Services.Workflow.RabbitMQ.Handler
{
    public class EntityAuditEventHandler : EventHandler<CreateEntityAuditEventMessage>
    {
        private readonly Connector _connector;

        public EntityAuditEventHandler(Connector connector)
        {
            _connector = connector;
        }

        public override void Execute()
        {
            _connector.EntityAudit.Create(Event.MetaData);
        }
    }
}
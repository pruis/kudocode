using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.Messaging.Infrastructure;

namespace Core.Services.Workflow.RabbitMQ.Handler
{
    public class TestEventHandler : EventHandler<TestEventMessage>
    {
        public override void Execute()
        {
            var x = Event.MetaData.Message;
        }
    }
}
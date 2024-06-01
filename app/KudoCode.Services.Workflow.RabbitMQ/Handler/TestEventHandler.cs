using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;

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
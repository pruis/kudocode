using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Emails;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.Web.Api.Connector;

namespace Core.Services.Workflow.RabbitMQ.Handler
{
	public class GetLeadEventHandler : EventHandler<GetLeadEventMessage>
	{
		private readonly Connector _connector;

		public GetLeadEventHandler(Connector connector)
		{
			_connector = connector;
		}

		public override void Execute()
		{
			_connector.EndPoint.Request<SendEmailRequest,int>(new SendEmailRequest() { ApplicationUserId = 0 });
		}
	}
}

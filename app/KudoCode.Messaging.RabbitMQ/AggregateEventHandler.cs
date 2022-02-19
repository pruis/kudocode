using KudoCode.Contracts;
using KudoCode.Contracts.Api;
using KudoCode.Helpers;
using KudoCode.Web.Api.Connector;
using System.Threading.Tasks;

namespace KudoCode.Messaging.RabbitMQ
{
	public class AggregateEventHandler : EventHandler<ApiControllerRequestDto>
	{
		private readonly Connector _connector;

		public AggregateEventHandler(Connector connector)
		{
			_connector = connector;
		}

		public override void Execute()
		{
			var method = _connector
				.EndPoint
				.GetType()
				.GetMethod("Request")
				.MakeGenericMethod(Event.MetaData.Request.GetType(),
					StaticHelpers.GetBusinessDtoType(Event.MetaData.ResponseType));

			Task.Run(
				() => method.Invoke(_connector.EndPoint,
					new[] { (object)Event.MetaData.Request })
			);
		}
	}
}
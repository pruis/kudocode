using KudoCode.Contracts;

namespace KudoCode.Contracts.Web
{
	public class EntityAuditConnector
	{
		private ConnectorClient connectorClient;

		public EntityAuditConnector(ConnectorClient connectorClient)
		{
			this.connectorClient = connectorClient;
		}

		public IApiResponseContextDto<int> Create(object dto)
		{
			var result = ConnectorCalls.Post<object, int>(connectorClient, dto, @"EntityAudit/Create");
			return result;
		}
	}
}
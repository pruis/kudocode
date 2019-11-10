using KudoCode.LogicLayer.Dtos.Lookups;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;

namespace KudoCode.Web.Api.Connector.Leads
{
	public class LookupsConnector
	{
		private ConnectorClient connectorClient;

		public LookupsConnector(ConnectorClient connectorClient)
		{
			this.connectorClient = connectorClient;
		}

		public IApiResponseContextDto<GetLookupResponse> Get(GetLookupRequest request)
		{
			var result = ConnectorCalls.Post<GetLookupRequest, GetLookupResponse>(connectorClient, request, @"Lookups/Get");
			return result;
		}
	}
}
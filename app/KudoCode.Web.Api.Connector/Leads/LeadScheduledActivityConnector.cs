using KudoCode.Contracts;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using System.Collections.Generic;

namespace KudoCode.Web.Api.Connector.Leads
{
	public class LeadScheduledActivityConnector
	{
		private ConnectorClient connectorClient;

		public LeadScheduledActivityConnector(ConnectorClient connectorClient)
		{
			this.connectorClient = connectorClient;
		}

		public IApiResponseContextDto<int> Create(CreateGetLeadScheduledActivityRequest request)
		{
			var result = ConnectorCalls.Post<CreateGetLeadScheduledActivityRequest, int>(connectorClient, request, @"LeadScheduledActivity/Create");
			request.Id = result.Result;
			return result;
		}

		public IApiResponseContextDto<int> Upate(UpdateGetLeadScheduledActivityRequest request)
		{
			var result = ConnectorCalls.Post<UpdateGetLeadScheduledActivityRequest, int>(connectorClient, request, @"LeadScheduledActivity/Update");
			request.Id = result.Result;
			return result;
		}

		public IApiResponseContextDto<GetLeadScheduledActivityResponse> Get(GetLeadScheduledActivityRequest request)
		{
				return ConnectorCalls.Post<GetLeadScheduledActivityRequest, GetLeadScheduledActivityResponse>(connectorClient, request, @"LeadScheduledActivity/GetOne");
		}

		public IApiResponseContextDto<List<GetLeadScheduledActivityResponse>> GetList(GetListLeadScheduledActivityRequest dto)
		{
			var result = ConnectorCalls.Post<GetListLeadScheduledActivityRequest, List<GetLeadScheduledActivityResponse>>(connectorClient, dto, @"LeadScheduledActivity/GetList");
			return result;
		}
	}
}
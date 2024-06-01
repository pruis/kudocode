using KudoCode.Contracts;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using System.Collections.Generic;

namespace KudoCode.Web.Api.Connector.Leads
{
	public class LeadConnector
    {
        private ConnectorClient connectorClient;

        public LeadConnector(ConnectorClient connectorClient)
        {
            this.connectorClient = connectorClient;
        }

        public IApiResponseContextDto<int> Create(CreateLeadRequest request)
        {
            var result = ConnectorCalls.Post<CreateLeadRequest, int>(connectorClient, request, @"Lead/Create");
            return result;
        }

        public IApiResponseContextDto<int> Update(UpdateLeadRequest request)
        {
            var result = ConnectorCalls.Post<UpdateLeadRequest, int>(connectorClient, request, @"Lead/Update");
            request.Id = result.Result;
            return result;
        }

        public IApiResponseContextDto<GetLeadResponse> GetSingle(GetLeadRequest request)
        {
            var result = ConnectorCalls.Post<GetLeadRequest, GetLeadResponse>(connectorClient, request, @"Lead/GetSingle");
            return result;
        }

        public IApiResponseContextDto<List<GetLeadResponse>> GetList(GetListLeadRequest dto)
        {
            var result = ConnectorCalls.Post<GetListLeadRequest, List<GetLeadResponse>>(connectorClient, dto, @"Lead/GetList");
            return result;
        }
    }
}
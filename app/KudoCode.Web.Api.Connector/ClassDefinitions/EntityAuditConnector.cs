using KudoCode.Contracts;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos;

namespace KudoCode.Web.Api.Connector.ClassDefinitions
{
	public class EntityAuditConnector
    {
        private ConnectorClient connectorClient;

        public EntityAuditConnector(ConnectorClient connectorClient)
        {
            this.connectorClient = connectorClient;
        }

        public IApiResponseContextDto<int> Create(CreateEntityAuditDto dto)
        {
            var result = ConnectorCalls.Post<CreateEntityAuditDto, int>(connectorClient, dto, @"EntityAudit/Create");
            return result;
        }
    }
}
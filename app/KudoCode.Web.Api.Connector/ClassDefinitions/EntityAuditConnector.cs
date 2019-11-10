using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;
using KudoCode.LogicLayer.Plugin.EntityAudit.Dtos;

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
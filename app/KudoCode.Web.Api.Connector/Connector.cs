using KudoCode.Contracts;
using KudoCode.Web.Api.Connector.ClassDefinitions;
using KudoCode.Web.Api.Connector.Leads;

namespace KudoCode.Web.Api.Connector
{
	public class Connector //: IConnector
    {
        public ConnectorClient ConnectorClient { get; set; }

        public readonly AuthenticationConnector Authentication;
        public readonly LeadConnector Lead;
        public readonly LookupsConnector Lookups;
        public readonly LeadScheduledActivityConnector LeadScheduledActivity;
        public readonly EntityAuditConnector EntityAudit;
        public readonly EndPointConnector EndPoint;

        public Connector(string url = null)
        {
            if (url == null)
                url = "https://localhost:63219/Api/";

            ConnectorClient = new ConnectorClient();
            ConnectorClient.NewClient(url);

            Authentication = new AuthenticationConnector(ConnectorClient);
            Lead = new LeadConnector(ConnectorClient);
            Lookups = new LookupsConnector(ConnectorClient);
            LeadScheduledActivity = new LeadScheduledActivityConnector(ConnectorClient);
            EntityAudit = new EntityAuditConnector(ConnectorClient);
            EndPoint = new EndPointConnector(ConnectorClient);
        }

        public void SetToken(ITokenDto token)
        {
            ConnectorClient.SetToken(token);
        }
    }
}
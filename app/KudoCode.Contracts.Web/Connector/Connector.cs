namespace KudoCode.Contracts.Web
{
	public class Connector //: IConnector
	{
		public ConnectorClient ConnectorClient { get; set; }

		public readonly AuthenticationConnector Authentication;
		public readonly EndPointConnector EndPoint;

		public readonly EntityAuditConnector EntityAudit;

		public Connector(string url = null)
		{
			if (url == null)
				url = "http://localhost:63219/Api/";

			ConnectorClient = new ConnectorClient();
			ConnectorClient.NewClient(url);

			Authentication = new AuthenticationConnector(ConnectorClient);
			EndPoint = new EndPointConnector(ConnectorClient);
			EntityAudit = new EntityAuditConnector(ConnectorClient);

		}

		public void SetToken(ITokenDto token)
		{
			ConnectorClient.SetToken(token);
		}
	}
}
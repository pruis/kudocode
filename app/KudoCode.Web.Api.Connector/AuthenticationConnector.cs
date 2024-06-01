using KudoCode.Contracts;

namespace KudoCode.Web.Api.Connector
{
	public class AuthenticationConnector
    {
        private readonly Api.Connector.ConnectorClient _connectorClient;

        public AuthenticationConnector(ConnectorClient connectorClient)
        {
            this._connectorClient = connectorClient;
        }

        public IApiResponseContextDto<ApplicationUserContext> Register(SaveApplicationUserRequest dto)
        {
            var result =
                ConnectorCalls.Post<SaveApplicationUserRequest, ApplicationUserContext>(_connectorClient, dto,
                    @"Authentication/Register");

            //if (!result.Errors.Any())
            //Settings.SetToken(result.Result);

            return result;
        }

        public IApiResponseContextDto<ApplicationUserContext> GetToken(GetTokenRequest request)
        {
            var result =
                ConnectorCalls.Post<GetTokenRequest, ApplicationUserContext>(_connectorClient, request,
                    @"Authentication/RequestToken");

            if (!result.HasErrors())
                _connectorClient.SetToken(result.Result.Token);

            return result;
        }

        public void SetToken(ITokenDto token)
        {
            _connectorClient.SetToken(token);
        }
    }
}
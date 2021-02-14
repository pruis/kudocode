using System.Linq;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens.Interfaces;

namespace KudoCode.Web.Api.Connector
{
    public class AuthenticationConnector
    {
        private readonly ConnectorClient _connectorClient;

        public AuthenticationConnector(ConnectorClient connectorClient)
        {
            this._connectorClient = connectorClient;
        }

        public IApiResponseContextDto<ApplicationUserContext> Register(RegisterApplicationUserDto dto)
        {
            var result =
                ConnectorCalls.Post<RegisterApplicationUserDto, ApplicationUserContext>(_connectorClient, dto,
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
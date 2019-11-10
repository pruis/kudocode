using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.Tokens
{
    public class GetTokenRequest : IApiRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
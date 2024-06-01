namespace KudoCode.Contracts
{

	public class GetTokenRequest : IApiRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
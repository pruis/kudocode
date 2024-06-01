namespace KudoCode.Contracts
{
    public class GetApplicationUserRequest : IApiRequestDto
    {
        public GetApplicationUserRequest()
        {

        }
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
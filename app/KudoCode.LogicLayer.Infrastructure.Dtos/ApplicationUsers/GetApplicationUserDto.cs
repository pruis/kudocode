using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers
{
    public class GetApplicationUserDto : IApiRequestDto

    {
        public GetApplicationUserDto(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }

}
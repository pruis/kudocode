using System.Collections.Generic;

namespace KudoCode.Contracts
{
    public class ListApplicationUserResponse : IListResponse<ApplicationUserResponse>
    {
        public ListApplicationUserResponse()
        {
            List = new List<ApplicationUserResponse>();
        }
        public List<ApplicationUserResponse> List { get; set; }
    }
    public class ApplicationUserResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ActiveEntityOrganization { get; set; }
    }
}

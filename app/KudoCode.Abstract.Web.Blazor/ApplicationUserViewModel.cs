using KudoCode.Contracts;
using KudoCode.Abstract.Web.Blazor;

namespace KudoCode.Abstract.Web.Blazor
{
    public class ApplicationUserViewModel
    {
        [VxIgnore]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string Repassword { get; set; }

        [VxFormDbLookup(Type = "EntityOrganization", Key = "Id", Value = "Name", Service = "Social", CacheOnFirstLoad = false)]
        public VxDbLookup ActiveEntityOrganization { get; set; }

    }
}

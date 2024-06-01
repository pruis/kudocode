using KudoCode.Contracts.Api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.Contracts.Api
{
    public class ApplicationUser : IEntityBasicAudit,
        IBelongToAuthorizationGroups<ApplicationUserAuthorizationGroupMap>, ILookup
    {
        //[Obsolete("used by ef")]
        public ApplicationUser()
        {
            EntityOrganizations = new List<ApplicationUserEntityOrganizationMap>();
            AuthorizationGroups = new List<ApplicationUserAuthorizationGroupMap>();
        }

        public ApplicationUser(string email, string password, string name, string surname)
        {
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
            EntityOrganizations = new List<ApplicationUserEntityOrganizationMap>();
            AuthorizationGroups = new List<ApplicationUserAuthorizationGroupMap>();
        }

        public void AddEntityOrganization(EntityOrganization entityOrganization)
        {
            if (!EntityOrganizations.Any(a => a.EntityOrganizationId == entityOrganization.Id))
                EntityOrganizations.Add(new ApplicationUserEntityOrganizationMap()
                { EntityOrganization = entityOrganization, ApplicationUser = this });
        }

        public void AddAuthorizationGroup(AuthorizationGroup authorizationGroup)
        {
            AuthorizationGroups.Add(new ApplicationUserAuthorizationGroupMap()
            { AuthorizationGroup = authorizationGroup, ApplicationUser = this });
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ActiveEntityOrganizationId { get; set; }
        public EntityOrganization ActiveEntityOrganization { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public int? AuthorizationRoleId { get; set; }
        public AuthorizationRole AuthorizationRole { get; set; }

        public List<ApplicationUserEntityOrganizationMap> EntityOrganizations { get; set; }
        public List<ApplicationUserAuthorizationGroupMap> AuthorizationGroups { get; set; }
        public string Secret { get; set; }
    }
}
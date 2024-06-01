using System.Collections.Generic;

namespace  KudoCode.Contracts
{
	public class GetApplicationUserResponse 
	{
		public GetApplicationUserResponse()
		{
			EntityOrganizations = new List<EntityOrganizationDto>();
			AuthorizationGroups = new List<AuthorizationGroupDto>();
		}

		public int Id { get; set; }
		public string Email { get; set; }
		public string Surname { get; set; }
		public string Name { get; set; }
		public VxDbLookup ActiveEntityOrganization { get; set; }
		public List<EntityOrganizationDto> EntityOrganizations { get; set; }
		public List<AuthorizationGroupDto> AuthorizationGroups { get; set; }

		public int? AuthorizationRoleId { get; set; }
		public AuthorizationRoleDto AuthorizationRole { get; set; }

	}
}
using System.Collections.Generic;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers
{
	public class ApplicationUserDto 
	{
		public ApplicationUserDto()
		{
			EntityOrganizations = new List<EntityOrganizationDto>();
			AuthorizationGroups = new List<AuthorizationGroupDto>();
		}

		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Surname { get; set; }
		public string Name { get; set; }
		public int ActiveEntityOrganizationId { get; set; }
		public List<EntityOrganizationDto> EntityOrganizations { get; set; }
		public List<AuthorizationGroupDto> AuthorizationGroups { get; set; }

		public int? AuthorizationRoleId { get; set; }
		public AuthorizationRoleDto AuthorizationRole { get; set; }

	}
}
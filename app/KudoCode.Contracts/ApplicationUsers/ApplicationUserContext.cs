using System.Collections.Generic;

namespace KudoCode.Contracts
{
	public class ApplicationUserContext : IApplicationUserContext
	{
		public ApplicationUserContext()
		{
			EntityOrganizations = new List<EntityOrganizationDto>();
			AuthorizationGroups = new List<AuthorizationGroupDto>();
			AuthorizationRole = new AuthorizationRoleDto();
			Token = new TokenDto();
		}
		public int Id { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public int ActiveEntityOrganizationId { get; set; }
		public IList<EntityOrganizationDto> EntityOrganizations { get; set; }
		public IList<AuthorizationGroupDto> AuthorizationGroups { get; set; }
		public IAuthorizationRoleDto AuthorizationRole { get; set; }
		public TokenDto Token { get; set; }
	}
}
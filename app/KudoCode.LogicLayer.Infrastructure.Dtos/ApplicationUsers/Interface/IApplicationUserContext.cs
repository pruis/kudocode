using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface
{
	public interface IApplicationUserContext
	{
		int ActiveEntityOrganizationId { get; set; }
		IList<AuthorizationGroupDto> AuthorizationGroups { get; set; }
		IList<EntityOrganizationDto> EntityOrganizations { get; set; }
		IAuthorizationRoleDto AuthorizationRole { get; set; }
		string Email { get; set; }
		int Id { get; set; }
		string Name { get; set; }
		string Surname { get; set; }
		TokenDto Token { get; set; }

	}
}
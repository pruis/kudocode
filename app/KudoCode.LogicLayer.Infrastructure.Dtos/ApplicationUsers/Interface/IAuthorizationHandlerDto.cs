using System.Collections.Generic;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface
{
	public interface IAuthorizationHandlerDto
	{
		IList<AuthorizationGroupDto> Groups { get; set; }
		IAuthorizationRoleDto Role { get; set; }
	}
}
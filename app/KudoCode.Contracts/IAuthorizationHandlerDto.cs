using KudoCode.Contracts;
using System.Collections.Generic;

namespace  KudoCode.Contracts
{
	public interface IAuthorizationHandlerDto
	{
		IList<AuthorizationGroupDto> Groups { get; set; }
		IAuthorizationRoleDto Role { get; set; }
	}
}
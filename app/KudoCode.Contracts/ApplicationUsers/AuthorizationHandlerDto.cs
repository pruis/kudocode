using System.Collections.Generic;

namespace  KudoCode.Contracts
{
	public class AuthorizationHandlerDto : IAuthorizationHandlerDto
	{
		public AuthorizationHandlerDto()
		{
			Groups = new List<AuthorizationGroupDto>();
		}
		public IList<AuthorizationGroupDto> Groups { get; set; }
		public IAuthorizationRoleDto Role { get; set; }
	}
}
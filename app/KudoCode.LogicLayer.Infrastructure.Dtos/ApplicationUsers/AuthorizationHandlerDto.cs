using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers
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
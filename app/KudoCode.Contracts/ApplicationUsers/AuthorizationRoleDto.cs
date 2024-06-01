using KudoCode.Contracts;

namespace  KudoCode.Contracts
{

	public class AuthorizationRoleDto : IAuthorizationRoleDto
	{

		public int Id { get; set; }
		public string Name { get; set; }

		public bool Read { get; set; }
		public bool Update { get; set; }
		public bool Delete { get; set; }
		public bool Create { get; set; }

		public int EntityOrganizationId { get; set; }
	}
}
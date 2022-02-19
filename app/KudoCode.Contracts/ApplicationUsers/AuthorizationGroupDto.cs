namespace  KudoCode.Contracts
{

	public class AuthorizationGroupDto : IAuthorizationGroupDto
	{

		public int Id { get; set; }
		public string Name { get; set; }

		public bool Read { get; set; }
		public bool Update { get; set; }
		public bool Delete { get; set; }
		public bool Create { get; set; }

		public int EntityOrganizationId { get; set; }
	}

	public interface IAuthorizationGroupDto
	{
		bool Create { get; set; }
		bool Delete { get; set; }
		int EntityOrganizationId { get; set; }
		int Id { get; set; }
		string Name { get; set; }
		bool Read { get; set; }
		bool Update { get; set; }
	}

}
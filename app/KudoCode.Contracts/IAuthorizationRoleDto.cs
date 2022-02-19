namespace  KudoCode.Contracts
{
	public interface IAuthorizationRoleDto
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
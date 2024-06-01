namespace KudoCode.Contracts
{
	public class SaveApplicationUserRequest : IApiRequestDto
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Repassword { get; set; }
		public string Surname { get; set; }
		public string Name { get; set; }
		public int ActiveEntityOrganizationId { get; set; }
	}
}
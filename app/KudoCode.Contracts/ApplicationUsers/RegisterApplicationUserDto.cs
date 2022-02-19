﻿namespace KudoCode.Contracts
{
	public class RegisterApplicationUserDto : IApiRequestDto
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string Repassword { get; set; }
		public string Surname { get; set; }
		public string Name { get; set; }
		public int ActiveEntityOrganizationId { get; set; }
	}
}
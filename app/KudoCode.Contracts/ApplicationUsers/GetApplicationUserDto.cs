namespace KudoCode.Contracts
{
	public class GetApplicationUserDto : IApiRequestDto

	{
		public GetApplicationUserDto(string email)
		{
			Email = email;
		}

		public string Email { get; set; }
	}

}
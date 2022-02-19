using System;

namespace KudoCode.Contracts
{
	public class TokenDto : ITokenDto
	{
		public TokenDto()
		{

		}

		public TokenDto(string value, DateTime validTo)
		{
			Value = value;
			ValidTo = validTo;
		}

		public string Value { get; set; }
		public DateTime ValidTo { get; set; }
		public bool IsValidTokenProvided { get; set; }

	}
}
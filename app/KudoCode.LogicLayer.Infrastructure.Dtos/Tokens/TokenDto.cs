using System;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.Tokens
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
	}
}
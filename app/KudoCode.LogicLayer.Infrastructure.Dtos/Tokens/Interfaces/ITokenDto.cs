using System;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.Tokens.Interfaces
{
	public interface ITokenDto
	{
		DateTime ValidTo { get; set; }
		string Value { get; set; }
	}
}
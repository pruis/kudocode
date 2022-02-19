using System;

namespace  KudoCode.Contracts
{
	public interface ITokenDto
	{
		DateTime ValidTo { get; set; }
		string Value { get; set; }
		bool IsValidTokenProvided { get; set; }

	}
}
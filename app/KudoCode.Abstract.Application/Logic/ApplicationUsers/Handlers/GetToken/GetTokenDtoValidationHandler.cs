using FluentValidation;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class GetTokenDtoValidationHandler : AbstractValidator<GetTokenRequest>
	{
		public GetTokenDtoValidationHandler()
		{
			RuleFor(x => x.Email).IsEmailAddress();
			RuleFor(x => x.Password).NotEmpty();
		}
	}

}
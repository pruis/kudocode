using FluentValidation;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Handlers.GetToken
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
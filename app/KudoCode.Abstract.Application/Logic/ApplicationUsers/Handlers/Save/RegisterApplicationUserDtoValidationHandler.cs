using FluentValidation;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class RegisterApplicationUserDtoValidationHandler : AbstractValidator<SaveApplicationUserRequest>
	{
		public RegisterApplicationUserDtoValidationHandler()
		{
			RuleFor(x => x.ActiveEntityOrganizationId).GreaterThan(0).NotEmpty();
			RuleFor(x => x.Email).IsEmailAddress();
		}
	}

}
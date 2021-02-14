using FluentValidation;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Handlers.RegisterApplicationUser
{
	public class RegisterApplicationUserDtoValidationHandler : AbstractValidator<RegisterApplicationUserDto>
	{
		public RegisterApplicationUserDtoValidationHandler()
		{
			RuleFor(x => x.ActiveEntityOrganizationId).GreaterThan(0).NotEmpty();
			RuleFor(x => x.Email).IsEmailAddress();
		}
	}

}
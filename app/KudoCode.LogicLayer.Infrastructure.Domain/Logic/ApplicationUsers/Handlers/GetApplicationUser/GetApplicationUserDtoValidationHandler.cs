using FluentValidation;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Handlers.GetApplicationUser
{

	public class GetApplicationUserDtoValidationHandler : AbstractValidator<GetApplicationUserDto>
	{
		public GetApplicationUserDtoValidationHandler()
		{
			RuleFor(x => x.Email).IsEmailAddress();
		}
	}
}
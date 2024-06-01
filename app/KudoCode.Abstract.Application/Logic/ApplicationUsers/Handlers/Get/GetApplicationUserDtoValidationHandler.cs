using FluentValidation;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{

	public class GetApplicationUserDtoValidationHandler : AbstractValidator<GetApplicationUserRequest>
	{
		public GetApplicationUserDtoValidationHandler()
		{
			RuleFor(x => x.Email).IsEmailAddress();
		}
	}
}
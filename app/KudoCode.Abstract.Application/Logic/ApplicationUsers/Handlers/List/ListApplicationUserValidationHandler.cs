using FluentValidation;
using KudoCode.Contracts;

namespace KudoCode.ApplicationUsersService.Domain
{
	public class ListApplicationUserValidationHandler : AbstractValidator<ListApplicationUserRequest>
	{
		public ListApplicationUserValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}



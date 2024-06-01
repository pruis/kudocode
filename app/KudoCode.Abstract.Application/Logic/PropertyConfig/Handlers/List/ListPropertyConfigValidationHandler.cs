using FluentValidation;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class ListPropertyConfigValidationHandler : AbstractValidator<ListPropertyConfigRequest>
	{
		public ListPropertyConfigValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}



using FluentValidation;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class SavePropertyConfigValidationHandler : AbstractValidator<SavePropertyConfigRequest>
	{
		public SavePropertyConfigValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}



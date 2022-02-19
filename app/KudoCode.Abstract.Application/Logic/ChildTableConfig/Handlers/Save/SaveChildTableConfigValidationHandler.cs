using FluentValidation;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class SaveChildTableConfigValidationHandler : AbstractValidator<SaveChildTableConfigRequest>
	{
		public SaveChildTableConfigValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}



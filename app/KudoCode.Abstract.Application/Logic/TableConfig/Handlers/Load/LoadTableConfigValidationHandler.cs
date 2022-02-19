using FluentValidation;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class LoadTableConfigValidationHandler : AbstractValidator<LoadTableConfigRequest>
	{
		public LoadTableConfigValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}



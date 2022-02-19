using FluentValidation;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class SaveTableConfigValidationHandler : AbstractValidator<SaveTableConfigRequest>
	{
		public SaveTableConfigValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}



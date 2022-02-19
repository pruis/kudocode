using FluentValidation;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class SaveDynamicValidationHandler : AbstractValidator<SaveDynamicRequest>
	{
		public SaveDynamicValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}



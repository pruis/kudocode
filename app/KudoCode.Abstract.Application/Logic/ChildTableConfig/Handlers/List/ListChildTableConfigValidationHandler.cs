using FluentValidation;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class ListChildTableConfigValidationHandler : AbstractValidator<ListChildTableConfigRequest>
	{
		public ListChildTableConfigValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}



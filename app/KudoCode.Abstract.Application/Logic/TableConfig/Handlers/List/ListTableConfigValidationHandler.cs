using FluentValidation;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class ListTableConfigValidationHandler : AbstractValidator<ListTableConfigRequest>
	{
		public ListTableConfigValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}



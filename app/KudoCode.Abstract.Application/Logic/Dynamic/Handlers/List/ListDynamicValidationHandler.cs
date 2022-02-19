using FluentValidation;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class ListDynamicValidationHandler : AbstractValidator<ListDynamicRequest>
	{
		public ListDynamicValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}



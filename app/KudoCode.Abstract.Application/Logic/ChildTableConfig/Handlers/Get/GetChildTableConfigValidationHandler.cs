using FluentValidation;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class GetChildTableConfigValidationHandler : AbstractValidator<GetChildTableConfigRequest>
	{
		public GetChildTableConfigValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}



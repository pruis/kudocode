using FluentValidation;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class GetPropertyConfigValidationHandler : AbstractValidator<GetPropertyConfigRequest>
	{
		public GetPropertyConfigValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}



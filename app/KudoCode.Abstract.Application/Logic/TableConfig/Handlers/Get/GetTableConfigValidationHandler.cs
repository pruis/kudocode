using FluentValidation;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class GetTableConfigValidationHandler : AbstractValidator<GetTableConfigRequest>
	{
		public GetTableConfigValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}



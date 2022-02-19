using FluentValidation;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class GetDynamicValidationHandler : AbstractValidator<GetDynamicRequest>
	{
		public GetDynamicValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}



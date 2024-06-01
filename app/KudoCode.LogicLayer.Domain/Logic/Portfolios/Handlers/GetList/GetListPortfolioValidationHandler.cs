using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using FluentValidation;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Handlers.GetList
{
	public class GetListPortfolioValidationHandler : AbstractValidator<GetListPortfolioRequest>
	{
		public GetListPortfolioValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}



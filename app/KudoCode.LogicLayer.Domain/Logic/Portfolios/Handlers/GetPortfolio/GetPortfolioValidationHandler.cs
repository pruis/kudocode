using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using FluentValidation;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Handlers.GetPortfolio
{
	public class GetPortfolioValidationHandler : AbstractValidator<GetPortfolioRequest>
	{
		public GetPortfolioValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
			RuleFor(x => x.Id).NotEmpty().NotNull();
		}
	}
}



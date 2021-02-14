using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using FluentValidation;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Handlers.GetList
{
	public class GetListPortfolioTransactionsSummaryValidationHandler : AbstractValidator<GetListPortfolioTransactionsSummaryRequest>
	{
		public GetListPortfolioTransactionsSummaryValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
			RuleFor(x => x.PortfolioId).NotEmpty().NotNull();
		}
	}
}



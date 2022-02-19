using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Outbound;
using FluentValidation;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsConsolidations.Handlers.GetList
{
	public class GetListPortfolioTransactionsConsolidationDtoValidationHandler : AbstractValidator<GetListPortfolioTransactionsConsolidationDto>
	{
		public GetListPortfolioTransactionsConsolidationDtoValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
			RuleFor(x => x.PortfolioTransactionsSummaryId).NotEmpty().NotNull();
		}
	}
}



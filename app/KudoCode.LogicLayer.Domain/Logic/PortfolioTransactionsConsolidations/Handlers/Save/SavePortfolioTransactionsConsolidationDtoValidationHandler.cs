using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Inbound;
using FluentValidation;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsConsolidations.Handlers.Save
{
    public class
        SavePortfolioTransactionsConsolidationDtoValidationHandler : AbstractValidator<
            SavePortfolioTransactionsConsolidationDto>
    {
        public SavePortfolioTransactionsConsolidationDtoValidationHandler()
        {
            RuleFor(x => x).NotEmpty().NotNull();
            RuleFor(x => x.PortfolioTransactionsSummaryId).NotEmpty().NotNull();
        }
    }
}
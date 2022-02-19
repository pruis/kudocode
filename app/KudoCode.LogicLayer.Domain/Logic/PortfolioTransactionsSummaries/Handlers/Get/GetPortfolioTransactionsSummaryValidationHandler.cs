using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using FluentValidation;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Handlers.Get
{
    public class
        GetPortfolioTransactionsSummaryValidationHandler : AbstractValidator<GetPortfolioTransactionsSummaryRequest>
    {
        public GetPortfolioTransactionsSummaryValidationHandler()
        {
            RuleFor(x => x).NotEmpty().NotNull();
            RuleFor(x => x.SummaryId).NotEmpty().NotNull();
        }
    }
}
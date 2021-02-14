using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Inbound;
using FluentValidation;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Domain;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Handlers.Save
{
    public class
        SavePortfolioTransactionsSummaryValidationHandler : AbstractValidator<SavePortfolioTransactionsSummaryRequest>
    {
        public SavePortfolioTransactionsSummaryValidationHandler()
        {
            //RuleFor(a => a.PreviousCloseAmount).GreaterThan(0);
            //RuleFor(a => a.CloseAmount).GreaterThan(0);
            //RuleFor(a => a.OpenAmount).GreaterThan(0);
            RuleFor(a => a.CloseDate).IsValidDate();
            RuleFor(a => a.OpenDate).IsValidDate();
        }
    }
}
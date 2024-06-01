using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Inbound;
using FluentValidation;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactions.Handlers.Save
{
    public class SavePortfolioTransactionValidationHandler : AbstractValidator<SavePortfolioTransactionRequest>
    {
        public SavePortfolioTransactionValidationHandler()
        {
            RuleFor(x => x).NotEmpty().NotNull();
            RuleFor(x => x.PortfolioId).NotEmpty().NotNull();
            RuleFor(x => x.PortfolioShareId).NotEmpty().NotNull();
            RuleFor(x => x.PortfolioTransactionTypeId).NotEmpty().NotNull();
        }
    }
}
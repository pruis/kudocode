using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound;
using FluentValidation;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactions.Handlers.Get
{
    public class GetPortfolioTransactionValidationHandler : AbstractValidator<GetPortfolioTransactionRequest>
    {
        public GetPortfolioTransactionValidationHandler()
        {
            RuleFor(x => x).NotEmpty().NotNull();
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.PortfolioId).NotEmpty().NotNull();
        }
    }
}
using KudoCode.LogicLayer.Dtos.ImportExcel;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using FluentValidation;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Handlers.SavePortfolio
{
    public class SavePortfolioValidationHandler : AbstractValidator<SavePortfolioRequest>
    {
        public SavePortfolioValidationHandler()
        {
            RuleFor(a => a.Name).NotEmpty().NotNull();
        }
    }
}
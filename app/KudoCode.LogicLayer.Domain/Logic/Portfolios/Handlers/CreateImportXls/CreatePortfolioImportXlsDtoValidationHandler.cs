using KudoCode.LogicLayer.Dtos.ImportExcel;
using FluentValidation;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Handlers.CreateImportXls
{
    public class CreatePortfolioImportXlsDtoValidationHandler : AbstractValidator<CreateImportXlsDto>
    {
        public CreatePortfolioImportXlsDtoValidationHandler()
        {
            RuleFor(x => x).NotEmpty().NotNull();
        }
    }
}
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.ImportExcel;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Handlers.CreateImportXls
{
	public class CreatePortfolioImportXlsDtoAuthorizationHandler : AbstractAuthorizationHandler<CreateImportXlsDto, int>
    {
        public CreatePortfolioImportXlsDtoAuthorizationHandler(IApplicationUserContext applicationUserContext,
            IAuthorizationContext<int> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
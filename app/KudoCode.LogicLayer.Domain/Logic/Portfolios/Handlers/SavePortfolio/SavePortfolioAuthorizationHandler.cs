using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Handlers.SavePortfolio
{
	public class SavePortfolioAuthorizationHandler : AbstractAuthorizationHandler<SavePortfolioRequest, int>
    {
        public SavePortfolioAuthorizationHandler(IApplicationUserContext applicationUserContext
            , IAuthorizationContext<int> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Handlers.GetPortfolio
{
	public class
        GetPortfolioAuthorizationHandler : AbstractAuthorizationHandler<GetPortfolioRequest, GetPortfolioResponse>
    {
        public GetPortfolioAuthorizationHandler(IApplicationUserContext applicationUserContext,
            IAuthorizationContext<GetPortfolioResponse> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
            AllowAnonymous = false;
        }
    }
}
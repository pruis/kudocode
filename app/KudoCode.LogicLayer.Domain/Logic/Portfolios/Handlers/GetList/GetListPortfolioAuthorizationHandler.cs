using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Handlers.GetList
{
	public class
        GetListPortfolioAuthorizationHandler : AbstractAuthorizationHandler<GetListPortfolioRequest,
            GetListPortfolioResponse>
    {
        public GetListPortfolioAuthorizationHandler(IApplicationUserContext applicationUserContext,
            IAuthorizationContext<GetListPortfolioResponse> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
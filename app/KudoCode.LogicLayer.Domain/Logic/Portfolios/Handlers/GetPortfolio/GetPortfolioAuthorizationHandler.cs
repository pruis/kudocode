using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

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
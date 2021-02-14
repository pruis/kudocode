using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

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
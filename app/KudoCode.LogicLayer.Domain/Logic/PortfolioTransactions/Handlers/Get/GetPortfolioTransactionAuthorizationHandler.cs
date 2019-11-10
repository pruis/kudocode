using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactions.Handlers.Get
{
    public class GetPortfolioTransactionAuthorizationHandler : AbstractAuthorizationHandler<
        GetPortfolioTransactionRequest, GetPortfolioTransactionResponse>
    {
        public GetPortfolioTransactionAuthorizationHandler(IApplicationUserContext applicationUserContext,
            IAuthorizationContext<GetPortfolioTransactionResponse> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
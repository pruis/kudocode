using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound;
using KudoCode.Contracts;

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
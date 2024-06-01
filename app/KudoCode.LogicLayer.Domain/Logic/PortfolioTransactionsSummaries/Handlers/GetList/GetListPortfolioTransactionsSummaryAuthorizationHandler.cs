using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Handlers.GetList
{
	public class GetListPortfolioTransactionsSummaryAuthorizationHandler : AbstractAuthorizationHandler<
        GetListPortfolioTransactionsSummaryRequest, GetListPortfolioTransactionsSummaryResponse>
    {
        public GetListPortfolioTransactionsSummaryAuthorizationHandler(
            IApplicationUserContext applicationUserContext,
            IAuthorizationContext<GetListPortfolioTransactionsSummaryResponse> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Inbound;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Handlers.Save
{
	public class
        SavePortfolioTransactionsSummaryAuthorizationHandler : AbstractAuthorizationHandler<
            SavePortfolioTransactionsSummaryRequest, int>
    {
        public SavePortfolioTransactionsSummaryAuthorizationHandler(IApplicationUserContext applicationUserContext,
            IAuthorizationContext<int> context) : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
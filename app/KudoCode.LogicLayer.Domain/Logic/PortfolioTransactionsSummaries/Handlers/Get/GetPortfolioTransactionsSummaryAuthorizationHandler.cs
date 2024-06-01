using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Handlers.Get
{

	public class GetPortfolioTransactionsSummaryAuthorizationHandler : AbstractAuthorizationHandler<GetPortfolioTransactionsSummaryRequest, GetPortfolioTransactionsSummaryResponse>
	{

		public GetPortfolioTransactionsSummaryAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<GetPortfolioTransactionsSummaryResponse> context) 
		: base(applicationUserContext, context)
		{
			IsLoggedIn();
		}
	}
}


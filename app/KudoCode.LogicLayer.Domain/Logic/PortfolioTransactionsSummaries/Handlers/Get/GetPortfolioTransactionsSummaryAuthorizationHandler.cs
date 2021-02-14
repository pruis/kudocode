using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

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


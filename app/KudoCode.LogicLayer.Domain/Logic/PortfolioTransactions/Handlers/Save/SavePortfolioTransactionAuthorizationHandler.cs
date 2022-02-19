using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Inbound;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactions.Handlers.Save
{

	public class SavePortfolioTransactionAuthorizationHandler : AbstractAuthorizationHandler<SavePortfolioTransactionRequest, int>
	{

		public SavePortfolioTransactionAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<int> context) 
		: base(applicationUserContext, context)
		{
			IsLoggedIn();
		}
	}
}


using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Inbound;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

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


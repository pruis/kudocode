using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Inbound;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

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
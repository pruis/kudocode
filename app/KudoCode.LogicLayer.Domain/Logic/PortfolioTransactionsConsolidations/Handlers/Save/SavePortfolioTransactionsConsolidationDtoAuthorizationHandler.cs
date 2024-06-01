using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Inbound;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsConsolidations.Handlers.Save
{
	public class
        SavePortfolioTransactionsConsolidationDtoAuthorizationHandler : AbstractAuthorizationHandler<
            SavePortfolioTransactionsConsolidationDto, int>
    {
        public SavePortfolioTransactionsConsolidationDtoAuthorizationHandler(
            IApplicationUserContext applicationUserContext, IAuthorizationContext<int> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
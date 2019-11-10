using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Inbound;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using NPOI.SS.Formula.Functions;

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
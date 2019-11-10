using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

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
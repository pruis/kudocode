using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.ImportExcel;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Handlers.SavePortfolio
{
    public class SavePortfolioAuthorizationHandler : AbstractAuthorizationHandler<SavePortfolioRequest, int>
    {
        public SavePortfolioAuthorizationHandler(IApplicationUserContext applicationUserContext
            , IAuthorizationContext<int> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
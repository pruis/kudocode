using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.ImportExcel;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Handlers.CreateImportXls
{
    public class CreatePortfolioImportXlsDtoAuthorizationHandler : AbstractAuthorizationHandler<CreateImportXlsDto, int>
    {
        public CreatePortfolioImportXlsDtoAuthorizationHandler(IApplicationUserContext applicationUserContext,
            IAuthorizationContext<int> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }
    }
}
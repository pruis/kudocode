using KudoCode.LogicLayer.Dtos.Authorization;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using NPOI.SS.Formula.Functions;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.Get
{
    public class GetLeadAuthorizationHandler : AbstractAuthorizationHandler<GetLeadRequest, GetLeadResponse>
    {
        public GetLeadAuthorizationHandler(IApplicationUserContext applicationUserContext
            , IAuthorizationContext<GetLeadResponse> context)
            : base(applicationUserContext, context)
        {
            IsLoggedIn();
        }

    }
}
using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.GetList
{
	public class GetLeadsDtoAuthorizationHandler : AbstractAuthorizationHandler<GetListLeadRequest, List<GetLeadResponse>>
	{
		public GetLeadsDtoAuthorizationHandler(IApplicationUserContext applicationUserContext
			, IAuthorizationContext<List<GetLeadResponse>> context)
			: base(applicationUserContext, context)
		{
			IsLoggedIn();
		}
	}
}
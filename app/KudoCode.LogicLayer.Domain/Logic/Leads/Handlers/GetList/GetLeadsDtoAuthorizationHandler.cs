using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.Contracts;
using System.Collections.Generic;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.GetList
{
	public class GetLeadsDtoAuthorizationHandler : AbstractAuthorizationHandler<GetListLeadRequest, List<GetLeadResponse>>
	{
		public GetLeadsDtoAuthorizationHandler(IApplicationUserContext applicationUserContext
			, IAuthorizationContext<List<GetLeadResponse>> context)
			: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
			//IsLoggedIn();
		}
	}
}
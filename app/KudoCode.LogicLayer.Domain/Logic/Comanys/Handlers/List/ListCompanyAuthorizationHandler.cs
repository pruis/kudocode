using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Comanys.Outbound;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.Companys.Handlers.List
{

	public class ListCompanyAuthorizationHandler : AbstractAuthorizationHandler<ListCompanyRequest, ListCompanyResponse>
	{

		public ListCompanyAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<ListCompanyResponse> context) 
		: base(applicationUserContext, context)
		{
            AllowAnonymous = true;
		}
	}
}


using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Comanys.Outbound;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.Companys.Handlers.Get
{

	public class GetCompanyAuthorizationHandler : AbstractAuthorizationHandler<GetCompanyRequest, GetCompanyResponse>
	{

		public GetCompanyAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<GetCompanyResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


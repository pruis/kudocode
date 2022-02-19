using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Companys.Outbound;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.Companys.Handlers.Save
{

	public class SaveCompanyAuthorizationHandler : AbstractAuthorizationHandler<SaveCompanyRequest, SaveCompanyResponse>
	{

		public SaveCompanyAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<SaveCompanyResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


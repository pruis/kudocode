using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Companys.Outbound;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.Companys.Handlers.Delete
{

	public class DeleteCompanyAuthorizationHandler : AbstractAuthorizationHandler<DeleteCompanyRequest, DeleteCompanyResponse>
	{

		public DeleteCompanyAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<DeleteCompanyResponse> context) 
		: base(applicationUserContext, context)
		{
			AllowAnonymous = true;
		}
	}
}


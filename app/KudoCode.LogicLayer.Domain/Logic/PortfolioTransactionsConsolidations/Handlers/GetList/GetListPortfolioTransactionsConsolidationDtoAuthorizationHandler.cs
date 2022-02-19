using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Outbound;
using KudoCode.Contracts;
using System.Collections.Generic;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsConsolidations.Handlers.GetList
{

	public class GetListPortfolioTransactionsConsolidationDtoAuthorizationHandler : AbstractAuthorizationHandler<GetListPortfolioTransactionsConsolidationDto, List<PortfolioTransactionsConsolidationDto>>
	{

		public GetListPortfolioTransactionsConsolidationDtoAuthorizationHandler(IApplicationUserContext applicationUserContext, IAuthorizationContext<List<PortfolioTransactionsConsolidationDto>> context) 
		: base(applicationUserContext, context)
		{
			IsLoggedIn();
		}
	}
}


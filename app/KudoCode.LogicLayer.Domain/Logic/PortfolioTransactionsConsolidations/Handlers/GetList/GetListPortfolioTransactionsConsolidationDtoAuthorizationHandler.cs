using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Outbound;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

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


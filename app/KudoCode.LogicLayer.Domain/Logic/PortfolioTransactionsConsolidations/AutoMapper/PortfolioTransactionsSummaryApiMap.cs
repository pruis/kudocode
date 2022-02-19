using System.Collections.Generic;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Entities;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Inbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;

using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsConsolidations.Entities;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Outbound;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsConsolidations.AutoMapper
{
	public class PortfolioTransactionsConsolidationApiMap : Profile
	{
		public PortfolioTransactionsConsolidationApiMap()
		{


			CreateMap<PortfolioTransactionsConsolidation, PortfolioTransactionsConsolidationDto>();
			//CreateMap<List<PortfolioTransactionsConsolidation>, List<PortfolioTransactionsConsolidationDto>>();

			//Source : Destination
			CreateMap<SavePortfolioTransactionsConsolidationDto, PortfolioTransactionsConsolidation>()
				.ForMember(dst => dst.PortfolioTransactionsSummaryId, o => o.Ignore())
				.ForMember(dst => dst.PortfolioTransactionsSummary, o => o.Ignore())
				;
		}
	}
}
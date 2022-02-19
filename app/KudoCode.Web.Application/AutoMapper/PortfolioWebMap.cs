using System.Collections.Generic;
using AutoMapper;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.Web.Application.Models;
using KudoCode.Web.Application.Models.Lead;
using KudoCode.Web.Application.Models.Leads;
using KudoCode.Web.Application.Models.LeadScheduledActivity;
using KudoCode.Web.Application.Models.Portfolios;
using KudoCode.Web.Application.Models.PortfolioTransactions;
using KudoCode.Web.Application.Models.PortfolioTransactionsSummary;

namespace KudoCode.Web.Application.AutoMapper
{
    public class PortfolioWebMap : Profile
    {
        public PortfolioWebMap()
        {
            CreateMap<GetPortfolioResponse, GetPortfolioViewModel>();
            CreateMap<GetPortfolioTransactionResponse, GetPortfolioTransactionViewModel>()
                .ForMember(dst => dst.PortfolioTransactionType, o => o.Ignore())
                .ForMember(dst => dst.PortfolioShare, o => o.Ignore())
                ;

            CreateMap<GetListPortfolioResponse, GetListPortfolioViewModel>();
            CreateMap<GetPortfolioTransactionsSummaryResponse, GetPortfolioTransactionsSummaryViewModel>();
        }
    }
}
using System;
using System.Globalization;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactions.Entities;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Inbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Inbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using Microsoft.Extensions.Configuration;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactions.AutoMapper
{
    public class PortfolioTransactionApiMap : Profile
    {
        public PortfolioTransactionApiMap(IConfiguration configuration)
        {
            //Source : Destination

            //INBOUND
            CreateMap<SavePortfolioTransactionRequest, PortfolioTransaction>()
                .ForMember(d => d.CreatedBy, o => o.Ignore())
                .ForMember(d => d.CreatedDate, o => o.Ignore())
                .ForMember(d => d.ModifiedBy, o => o.Ignore())
                .ForMember(d => d.ModifiedDate, o => o.Ignore())
                .ForMember(d => d.PortfolioShare, o => o.Ignore())
                .ForMember(d => d.Portfolio, o => o.Ignore())
                .ForMember(d => d.PortfolioTransactionType, o => o.Ignore())
                ;

            //OUTBOUND
            CreateMap<PortfolioTransaction, GetPortfolioTransactionResponse>()
                .ForMember(d => d.Date,
                    o => o.MapFrom(s => s.Date.ToString(configuration["DateFormat"])))
                ;

            CreateMap<PortfolioTransaction, PortfolioTransactionResponse>()
                .ForMember(d => d.Date,
                    o => o.MapFrom(s => s.Date.ToString(configuration["DateFormat"])))
                .ForMember(d => d.PortfolioShareDescription,
                    o => o.MapFrom(s => s.PortfolioShare.Description))
                .ForMember(d => d.PortfolioTransactionType,
                    o => o.MapFrom(s => s.PortfolioTransactionType.Description))
                ;
        }
    }
}
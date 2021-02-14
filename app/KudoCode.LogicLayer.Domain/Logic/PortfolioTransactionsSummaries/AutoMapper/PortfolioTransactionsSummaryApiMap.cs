using System;
using System.Globalization;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Entities;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Inbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using Microsoft.Extensions.Configuration;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.AutoMapper
{
    public class PortfolioTransactionsSummaryApiMap : Profile
    {
        public PortfolioTransactionsSummaryApiMap(IConfiguration configuration)
        {
            //Source : Destination

            //INBOUND
            CreateMap<SavePortfolioTransactionsSummaryRequest, PortfolioTransactionsSummary>()
                .ForMember(dst => dst.PortfolioId, o => o.Ignore())
                .ForMember(dst => dst.Portfolio, o => o.Ignore())
                .ForMember(d => d.OpenDate, o =>
                    o.MapFrom(s =>
                        DateTime.Parse(s.OpenDate, CultureInfo.InvariantCulture)))
                .ForMember(d => d.CloseDate, o =>
                    o.MapFrom(s =>
                        DateTime.Parse(s.CloseDate, CultureInfo.InvariantCulture)))
                ;

            //OUTBOUND
            CreateMap<PortfolioTransactionsSummary, GetPortfolioTransactionsSummaryResponse>()
                .ForMember(d => d.OpenDate, o => o.MapFrom(s => S(configuration, s)))
                .ForMember(d => d.CloseDate, o => o.MapFrom(s => s.CloseDate.ToString(configuration["DateFormat"])))
                ;
        }

        private static string S(IConfiguration configuration, PortfolioTransactionsSummary s)
        {
            var x = s.OpenDate.ToString(configuration["DateFormat"]);
            return x;
        }
    }
}
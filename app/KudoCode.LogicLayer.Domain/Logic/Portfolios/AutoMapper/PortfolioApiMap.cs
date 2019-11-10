using System;
using System.Globalization;
using System.Linq;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.Portfolios.Entities;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using Microsoft.Extensions.Configuration;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.AutoMapper
{
    public class PortfolioApiMap : Profile
    {
        public PortfolioApiMap(IConfiguration configuration)
        {
            //Source : Destination

            //INBOUND
            CreateMap<SavePortfolioRequest, Portfolio>()
                .ForMember(d => d.OpenDate, o =>
                    o.MapFrom(s =>
                        DateTime.ParseExact(s.OpenDate, configuration["DateFormat"], CultureInfo.InvariantCulture)))
                .ForMember(dst => dst.Id,
                    o => o.Ignore())
                ;

            //OUTBOUND
            CreateMap<Portfolio, GetPortfolioResponse>()
                .ForMember(d => d.TransactionsSummaries,
                    o => o.MapFrom(s => s.TransactionsSummaries.OrderByDescending(a => a.CloseDate)))
                .ForMember(d => d.Transactions,
                    o => o.MapFrom(s => s.Transactions.OrderByDescending(a => a.Date)))
                .ForMember(d => d.OpenDate, o => o.MapFrom(s => s.OpenDate.ToString(configuration["DateFormat"])));

            //OUTBOUND
            CreateMap<Portfolio, PortfolioResponse>()
                .ForMember(d => d.OpenDate, o => o.MapFrom(s => s.OpenDate.ToString(configuration["DateFormat"])));
        }
    }
}
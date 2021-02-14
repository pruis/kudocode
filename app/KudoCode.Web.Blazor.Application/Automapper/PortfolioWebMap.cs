using System;
using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Web.Blazor.Application.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using ServiceStack.Redis;

namespace KudoCode.Web.Blazor.Application.AutoMapper
{
    public class PortfolioWebMap : Profile
    {
        [Inject] public IConfiguration Configuration { get; set; }

        public PortfolioWebMap()
        {
            CreateMap<GetPortfolioViewModel, SavePortfolioRequest>()
                .ForMember(a => a.OpenDate,
                    o => o.MapFrom(src => src.OpenDate.ToString("yyyy-MM-dd")))
                ;


            CreateMap<GetListPortfolioResponse, GetListPortfolioViewModel>();


            CreateMap<GetPortfolioResponse, GetPortfolioViewModel>()
                .ForMember(a => a.OpenDate,
                    o => o.MapFrom(src =>
                        DateTime.ParseExact(src.OpenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)));
        }
    }
}
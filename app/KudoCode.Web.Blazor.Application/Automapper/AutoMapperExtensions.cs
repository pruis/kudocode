using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses;
using KudoCode.Web.Infrastructure.Domain.Execution;

namespace KudoCode.Web.Blazor.Application.AutoMapper
{
    public class AutoMapperExtensions : Profile
    {
        public AutoMapperExtensions()
        {

            CreateMap<ApplicationUserContext, ApplicationUserContext>();

            CreateMap(typeof(ApiResponseContextDto<>), typeof(WebResponseDto<>))
                .ForMember("Configuration", o => o.Ignore())
                .ForMember("Errors", o => o.Ignore())
                .ForMember("Redirect", o => o.Ignore());
            //.ReverseMap();
        }
    }
}
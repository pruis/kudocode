using AutoMapper;
using KudoCode.Contracts;
using KudoCode.Contracts.Web;
using System;

namespace KudoCode.Web.Application.AutoMapper
{

	public class AutoMapperExtensions : Profile
	{
		public AutoMapperExtensions()
		{
			CreateMap(typeof(ApiResponseContextDto<>), typeof(WebResponseDto<>))
				.ForMember("Configuration", o => o.Ignore())
				.ForMember("Errors", o => o.Ignore())
				.ForMember("Redirect", o => o.Ignore())
				//.ForMember("Result", o => o.MapFrom(d=>d.Result))
				//.ReverseMap()
				;
		}
	}
}

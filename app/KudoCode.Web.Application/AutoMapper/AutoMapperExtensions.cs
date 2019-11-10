using System.Linq;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses;
using KudoCode.Web.Application.Models;
using KudoCode.Web.Infrastructure.Domain.Execution;
using ServiceStack.Redis.Support.Queue.Implementation;


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

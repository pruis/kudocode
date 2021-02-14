using KudoCode.Web.Infrastructure.Domain.Execution;
using System.Collections.Generic;
using AutoMapper;
using KudoCode.Web.Api.Connector;

using KudoCode.LogicLayer.Dtos.Leads;


namespace KudoCode.Web.Application.Handlers
{
	public class LeadsWebHandler : IWebHandler<GetListLeadRequest, List<GetLeadResponse>>
	{
		private readonly Connector _connector;
		private readonly IMapper _mapper;

		public LeadsWebHandler(Connector connector, IMapper mapper)
		{
			_connector = connector;
			_mapper = mapper;
		}

		//Get
		public IWebResponseDto<List<GetLeadResponse>> Handle(GetListLeadRequest dto, IWebResponseDto<List<GetLeadResponse>> webResponseDto)
		{
			var apiResponse = _connector.Lead.GetList(dto);
			_mapper.Map(apiResponse, webResponseDto);
			//webResponseDto.Messages = apiResponse.Messages;
			//webResponseDto.Result = apiResponse.Result;

			return webResponseDto;
		}
	}
}
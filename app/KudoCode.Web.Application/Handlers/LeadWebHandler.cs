using AutoMapper;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.Contracts;
using KudoCode.Web.Api.Connector;
using KudoCode.Web.Application.Models.Lead;
using KudoCode.Contracts.Web;
using System.Linq;

namespace KudoCode.Web.Application.Handlers
{
	public class LeadWebHandler : IWebHandler<GetLeadRequest, LeadViewModel>, IWebHandler<LeadViewModel, int>
	{
		private readonly Api.Connector.Connector _connector;
		private readonly IMapper _mapper;

		public LeadWebHandler(Api.Connector.Connector connector, IMapper mapper)
		{
			_connector = connector;
			_mapper = mapper;
		}

		//Get
		public IWebResponseDto<LeadViewModel> Handle(GetLeadRequest request, IWebResponseDto<LeadViewModel> webResponseDto)
		{
			var lookupResponse = _connector.EndPoint.Request<GetLookupRequest, GetLookupResponse>(
				dto: new GetLookupRequest(new[]
				{
					new LookupRequest() {Type = "Gender"},
					new LookupRequest() {Type = "Occupation"},
					new LookupRequest() {Type = "CurrentAdvisor"},
				}));
			webResponseDto.Messages.AddRange(lookupResponse.Messages);

			if (webResponseDto.Messages.Any(a => a.Type == MessageDtoType.Error))
				return webResponseDto;


			webResponseDto.Result.Genders = Extensions.AssignLookupValues(lookupResponse.Result, "Gender");
			webResponseDto.Result.Occupations = Extensions.AssignLookupValues(lookupResponse.Result, "Occupation");
			webResponseDto.Result.CurrentAdvisors = Extensions.AssignLookupValues(lookupResponse.Result, "CurrentAdvisor");

			if (request.Id == 0)
				return webResponseDto;

			var apiResponseDto = _connector.Lead.GetSingle(request);
			_mapper.Map(apiResponseDto, webResponseDto);


			return webResponseDto;
		}

		//Save
		public IWebResponseDto<int> Handle(LeadViewModel vm, IWebResponseDto<int> responseDto)
		{
			IApiResponseContextDto<int> result = null;
			if (vm.Id == 0)
				result = _connector.Lead.Create(_mapper.Map<CreateLeadRequest>(vm));

			else
				result = _connector.Lead.Update(_mapper.Map<UpdateLeadRequest>(vm));

			_mapper.Map(result, responseDto);

			if (!responseDto.HasErrors())
				responseDto.Messages.Add(new MessageDto("M1", "Success", 0));
			return responseDto;
		}

	}
}
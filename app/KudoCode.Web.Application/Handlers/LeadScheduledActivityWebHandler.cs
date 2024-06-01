using AutoMapper;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.Web.Api.Connector;
using KudoCode.Web.Application.Models.LeadScheduledActivity;
using KudoCode.Contracts.Web;

namespace KudoCode.Web.Application.Handlers
{

	public class LeadScheduledActivityWebHandler :
		IWebHandler<Get, LeadScheduledActivityViewModel>,
		IWebHandler<LeadScheduledActivityViewModel, int>
	{
		private readonly Api.Connector.Connector _connector;
		private readonly IMapper _mapper;

		public LeadScheduledActivityWebHandler(Api.Connector.Connector connector, IMapper mapper)
		{
			_connector = connector;
			_mapper = mapper;
		}

		//Get
		public IWebResponseDto<LeadScheduledActivityViewModel> Handle(Get dto, IWebResponseDto<LeadScheduledActivityViewModel> webResponseDto)
		{
			if (dto.Id == 0)
				webResponseDto.Result.LeadId = dto.LeadId;
			else
				_mapper.Map(_connector.LeadScheduledActivity.Get(new GetLeadScheduledActivityRequest() { Id = dto.Id, LeadId = dto.LeadId }), webResponseDto);

			var lookupResponse = _connector.EndPoint.Request<GetLookupRequest, GetLookupResponse>(
				dto: new GetLookupRequest(new[]
				{
					new LookupRequest() {Type = "LeadScheduledActivityType"},
					new LookupRequest() {Type = "AddressType"},
				}));
			webResponseDto.Messages.AddRange(lookupResponse.Messages);

			webResponseDto.Result.LeadScheduledActivityTypes = Extensions.AssignLookupValues(lookupResponse.Result, "LeadScheduledActivityType");
			webResponseDto.Result.Address.AddressTypes = Extensions.AssignLookupValues(lookupResponse.Result, "AddressType");

			return webResponseDto;
		}

		//Save
		public IWebResponseDto<int> Handle(LeadScheduledActivityViewModel dto, IWebResponseDto<int> webResponseDto)
		{
			IApiResponseContextDto<int> apiResponseDto;

			if (dto.Id == 0)
				apiResponseDto = _connector.LeadScheduledActivity.Create(_mapper.Map<CreateGetLeadScheduledActivityRequest>(dto));
			else
				apiResponseDto = _connector.LeadScheduledActivity.Upate(_mapper.Map<UpdateGetLeadScheduledActivityRequest>(dto));

			_mapper.Map(apiResponseDto, webResponseDto);

			return webResponseDto;
		}

	}
}
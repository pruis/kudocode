using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.Leads
{
	public class CreateLeadRequest : IApiRequestDto
	{
		public LeadPersonalInformationDto LeadPersonalInformation { get; set; }
	}
}
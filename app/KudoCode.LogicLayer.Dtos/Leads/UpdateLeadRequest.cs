using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.Leads
{
	public class UpdateLeadRequest : IApiRequestDto
	{
		public int Id { get; set; }
		public int? LeadPersonalInformationId { get; set; }
		public LeadPersonalInformationDto LeadPersonalInformation { get; set; }
	}
}
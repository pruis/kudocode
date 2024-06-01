using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.Leads
{
	public class UpdateLeadRequest : IApiRequestDto
	{
		public int Id { get; set; }
		public int? LeadPersonalInformationId { get; set; }
		public LeadPersonalInformationDto LeadPersonalInformation { get; set; }
	}
}
using KudoCode.Contracts;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.Leads
{
	public class CreateLeadRequest : IApiRequestDto
	{
		public LeadPersonalInformationDto LeadPersonalInformation { get; set; }
	}
}
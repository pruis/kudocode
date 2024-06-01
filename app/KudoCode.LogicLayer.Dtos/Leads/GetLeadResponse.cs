using KudoCode.Contracts;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using System.Collections.Generic;

namespace KudoCode.LogicLayer.Dtos.Leads
{
	public class GetLeadResponse : IApiRequestDto
	{
	    public int Id { get; set; }

		public string Email { get; set; }
	    public string Name { get; set; }
		//Testing
	    public string ApplicationUserEmail { get; set; }

		public int? LeadPersonalInformationId { get; set; }
	    public LeadPersonalInformationDto LeadPersonalInformation { get; set; }

		public List<GetLeadScheduledActivityResponse> LeadScheduledActivities { get; set; }

		public int AgentId { get; set; }
		public ApplicationUserDtoBasic Agent { get; set; }

	}

}

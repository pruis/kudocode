using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

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

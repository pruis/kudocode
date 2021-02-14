using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.LeadScheduledActivities
{
	public class CreateGetLeadScheduledActivityRequest : GetLeadScheduledActivityResponse, IApiRequestDto, ILeadScheduledActivityDto
	{
		public new int LeadId { get; set; }
	}
}
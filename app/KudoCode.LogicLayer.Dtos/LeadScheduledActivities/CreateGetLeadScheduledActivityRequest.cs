using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.LeadScheduledActivities
{
	public class CreateGetLeadScheduledActivityRequest : GetLeadScheduledActivityResponse, IApiRequestDto
	{
		public new int LeadId { get; set; }
	}
}
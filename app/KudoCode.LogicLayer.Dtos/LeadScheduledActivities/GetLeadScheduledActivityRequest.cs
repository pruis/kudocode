
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.LeadScheduledActivities
{
	public class GetLeadScheduledActivityRequest: IApiRequestDto
	{
		public int Id { get; set; }
		public int LeadId { get; set; }
	}
}
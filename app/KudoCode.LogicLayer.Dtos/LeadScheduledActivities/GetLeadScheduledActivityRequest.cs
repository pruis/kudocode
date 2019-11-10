
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.LeadScheduledActivities
{
	public class GetLeadScheduledActivityRequest: IApiRequestDto
	{
		public int Id { get; set; }
		public int LeadId { get; set; }
	}
}
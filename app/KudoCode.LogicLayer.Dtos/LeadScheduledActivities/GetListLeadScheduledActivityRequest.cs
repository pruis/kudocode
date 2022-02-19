using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.LeadScheduledActivities
{
	public class GetListLeadScheduledActivityRequest : IApiRequestDto
    {
        public int LeadId { get; set; }
    }
}
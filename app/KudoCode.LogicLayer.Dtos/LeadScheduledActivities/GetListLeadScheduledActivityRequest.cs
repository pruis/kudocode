using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.LeadScheduledActivities
{
    public class GetListLeadScheduledActivityRequest : IApiRequestDto
    {
        public int LeadId { get; set; }
    }
}
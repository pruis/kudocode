using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Lookups;

namespace KudoCode.LogicLayer.Dtos.LeadScheduledActivities
{
	public interface ILeadScheduledActivityDto
	{
		AddressDto Address { get; set; }
		int? AddressId { get; set; }
		List<AddressTypeDto> AddressTypes { get; set; }
		string AppointmentDateTime { get; set; }
		int Id { get; set; }
		int LeadId { get; set; }
		LeadScheduledActivityTypeDto LeadScheduledActivityType { get; set; }
		int LeadScheduledActivityTypeId { get; set; }
		string Notes { get; set; }
	}
}
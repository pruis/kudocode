using System;
using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Lookups;

namespace KudoCode.Web.Application.Models.LeadScheduledActivity
{

	public class LeadScheduledActivityViewModel
	{
	    public LeadScheduledActivityViewModel()
	    {
			LeadScheduledActivityTypes = new List<LookupResponse>();
			Address = new AddressDto();
			AppointmentDateTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
		}

	    public string FormId { get; set; }

		public int Id { get; set; }
		public int LeadId { get; set; }
		public string AppointmentDateTime { get; set; }
		public string Notes { get; set; }
		public int? AddressId { get; set; }
		public AddressDto Address { get; set; }
		//selected 
		public int LeadScheduledActivityTypeId { get; set; }
		
		//lookups
		public List<LookupResponse> LeadScheduledActivityTypes { get; internal set; }
	}
}

using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.Lookups.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Entities
{
	public class LeadScheduledActivity : IEntity
	{
		public int Id { get; set; }
		public DateTime AppointmentDateTime { get; set; }

		[StringLength(255)]
		public string Notes { get; set; }

		public int? AddressId { get; set; }
		public Address Address { get; set; }

		public int LeadScheduledActivityTypeId { get; set; }
		public LeadScheduledActivityType LeadScheduledActivityType { get; set; }

		public int LeadId { get; set; }
		public Lead Lead { get; set; }

	}

}
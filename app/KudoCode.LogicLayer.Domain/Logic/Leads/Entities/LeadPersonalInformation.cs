using KudoCode.LogicLayer.Domain.Logic.Lookups.Entities;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Entities
{
	public class LeadPersonalInformation : IEntity
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string Surname { get; set; }
		public int Age { get; set; }
		public string Cellphone { get; set; }
		public string Landline { get; set; }
		public string Email { get; set; }
		public bool FreeWill { get; set; }

		public int? GenderId { get; set; }
		public Gender Gender { get; set; }

		public int? CurrentAdvisorId { get; set; }
		public CurrentAdvisor CurrentAdvisor { get; set; }

		public int? OccupationId { get; set; }
		public Occupation Occupation { get; set; }

		public int LeadId { get; set; }
		public Lead Lead { get; set; }
	}


}
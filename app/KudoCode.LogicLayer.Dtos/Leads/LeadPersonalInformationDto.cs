using KudoCode.LogicLayer.Dtos.Lookups;

namespace KudoCode.LogicLayer.Dtos.Leads
{
	public class LeadPersonalInformationDto
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
		public GenderDto Gender { get; set; }

		public int CurrentAdvisorId { get; set; }
		public CurrentAdvisorDto CurrentAdvisor { get; set; }

		public int OccupationId { get; set; }
		public OccupationDto Occupation { get; set; }

	}


}
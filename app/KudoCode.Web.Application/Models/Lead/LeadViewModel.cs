using System.Collections.Generic;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.Contracts;

namespace KudoCode.Web.Application.Models.Lead
{
    public class LeadViewModel
    {
	    public LeadViewModel()
	    {
			Genders= new List<LookupResponse>();
			CurrentAdvisors= new List<LookupResponse>();
			Occupations = new List<LookupResponse>();
		}

	    public string FormId { get; set; }
	    public int Id { get; set; }
	    public string FirstName { get; set; }
	    public string Surname { get; set; }
	    public int Age { get; set; }
	    public string Cellphone { get; set; }
	    public string Landline { get; set; }
	    public string Email { get; set; }
	    public bool FreeWill { get; set; }

		public List<GetLeadScheduledActivityResponse> LeadScheduledActivities { get; set; }

		//selected 
		public int GenderId { get; set; }
	    public int CurrentAdvisorId { get; set; }
		public int OccupationId { get; set; }

		//lookups
		public List<LookupResponse> CurrentAdvisors { get; set; }
	    public List<LookupResponse> Genders { get; set; }
	    public List<LookupResponse> Occupations { get; set; }
		
	}
}

using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.Leads;

namespace KudoCode.Web.Application.Models.Leads
{
	public class LeadsViewModel
	{
		public LeadsViewModel()
		{
			Leads = new List<GetLeadResponse>();
		}

		public string SearchText { get; set; }
		public List<GetLeadResponse> Leads { get; set; }
	}
}
using KudoCode.Contracts;
using System;
using System.Collections.Generic;

namespace KudoCode.LogicLayer.Dtos.Comanys.Outbound
{
	public class ListCompanyResponse : IListResponse<CompanyResponse>
	{
		public ListCompanyResponse()
		{
			List = new List<CompanyResponse>();
		}

		public List<CompanyResponse> List { get; set; }
	}
	public class CompanyResponse
    {
        public int Id {get;set;}
        public string Name {get;set;}
		public string LastName { get; set; }
		public string Address { get; set; }

		public DateTime Date {get;set;}
    }
}

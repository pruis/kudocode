using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VxFormGenerator.Core;
using VxFormGenerator.Core.Layout;

namespace KudoCode.LogicLayer.Dtos.Comanys.Outbound
{
	public class GetCompanyResponse
	{
		[VxIgnore]
		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public DateTime Date { get; set; }

		public cc ddd { get; set; } 
		public VxLookupList Leads { get; set; } = new VxLookupList() ;

	}

	public enum cc
	{ test,testtt,testee,eee}
}

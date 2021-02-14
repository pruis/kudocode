using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.Leads
{
	public class GetListLeadRequest: IApiRequestDto
	{
		public string Email { get; set; }
		public string Name { get; set; }
	}
	public class UploadLeadsDto
	{
		public List<GetLeadResponse> Leads { get; set; }
	}

}
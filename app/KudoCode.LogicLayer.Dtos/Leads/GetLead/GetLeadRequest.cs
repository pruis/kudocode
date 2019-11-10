using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.Leads.GetLead
{
	public class GetLeadRequest : IApiRequestDto
	{
		public int Id { get; set; }
	}
}
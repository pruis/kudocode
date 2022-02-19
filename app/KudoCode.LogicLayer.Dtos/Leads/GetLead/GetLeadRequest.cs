using KudoCode.Contracts;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.Leads.GetLead
{
	public class GetLeadRequest : IApiRequestDto
	{
		public int Id { get; set; }
	}
}
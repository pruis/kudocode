using KudoCode.Contracts.Api;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Entities
{
	public class LeadAuthorizationGroupMap : IEntity, IBelongToGroup
	{
		public int Id { get; set; }

		public int LeadId { get; set; }
		public Lead Lead { get; set; }

		public int AuthorizationGroupId { get; set; }
		public AuthorizationGroup AuthorizationGroup { get; set; }
	}
}
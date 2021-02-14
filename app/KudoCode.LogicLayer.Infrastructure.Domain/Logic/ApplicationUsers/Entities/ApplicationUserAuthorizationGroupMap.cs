using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Entities
{
	public class ApplicationUserAuthorizationGroupMap : IEntity, Interfaces.IBelongToApplicationUser,Interfaces.IBelongToGroup
	{
		public int Id { get; set; }
		public int ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		public int AuthorizationGroupId { get; set; }
		public AuthorizationGroup AuthorizationGroup { get; set; }
	}
}
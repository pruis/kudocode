namespace KudoCode.Contracts.Api
{
	public class ApplicationUserAuthorizationGroupMap : IEntity, IBelongToGroup
	{
		public int Id { get; set; }
		public int ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		public int AuthorizationGroupId { get; set; }
		public AuthorizationGroup AuthorizationGroup { get; set; }
	}
}
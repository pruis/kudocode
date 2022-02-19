
namespace KudoCode.Contracts.Api
{
	public class AuthorizationGroup : IEntity, IBelongToOrganization, ILookup
	{
		public AuthorizationGroup()
		{
			Delete = true;
			Read = true;
			Update = true;
			Create = true;
		}

		public int Id { get; set; }
		public string Name { get; set; }

		public bool Update { get; set; }
		public bool Delete { get; set; }
		public bool Create { get; set; }
		public bool Read { get; set; }

		public int EntityOrganizationId { get; set; }
		public EntityOrganization EntityOrganization { get; set; }
	}
}
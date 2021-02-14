using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Entities.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Entities
{
	public class AuthorizationRole : IEntity,IBelongToOrganization
	{
		public AuthorizationRole()
		{
			Delete = true;
			Read = true;
			Update = true;
			Create = true;
		}

		public int Id { get; set; }
		public string Name { get; set; }

		public bool Read { get; set; }
		public bool Update { get; set; }
		public bool Delete { get; set; }
		public bool Create { get; set; }

		public int EntityOrganizationId { get; set; }
		public EntityOrganization EntityOrganization { get; set; }
	}
}
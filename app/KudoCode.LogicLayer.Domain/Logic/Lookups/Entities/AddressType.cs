using KudoCode.Contracts.Api;
using System.ComponentModel.DataAnnotations.Schema;
using KudoCode.Contracts.Api;


namespace KudoCode.LogicLayer.Domain.Logic.Lookups.Entities
{
	public class AddressType : IEntity, IBelongToOrganization, ILookup
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		public string Description { get; set; }
		public int EntityOrganizationId { get; set; }
		public EntityOrganization EntityOrganization { get; set; }
	}
}
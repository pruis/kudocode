
using System;

namespace KudoCode.Contracts.Api
{
	public interface IEntityOrganization
	{
		string CreatedBy { get; set; }
		DateTime CreatedDate { get; set; }
		int Id { get; set; }
		string ModifiedBy { get; set; }
		DateTime ModifiedDate { get; set; }
		string Name { get; set; }
	}
	public interface IBelongToOrganization : IBelongsTo
	{
		int EntityOrganizationId { get; set; }
		EntityOrganization EntityOrganization { get; set; }
	}
}
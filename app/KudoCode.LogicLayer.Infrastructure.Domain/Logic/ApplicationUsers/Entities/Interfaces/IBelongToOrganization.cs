
namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Entities.Interfaces
{
	public interface IBelongToOrganization : IBelongsTo
	{
		int EntityOrganizationId { get; set; }
		EntityOrganization EntityOrganization { get; set; }
	}
}
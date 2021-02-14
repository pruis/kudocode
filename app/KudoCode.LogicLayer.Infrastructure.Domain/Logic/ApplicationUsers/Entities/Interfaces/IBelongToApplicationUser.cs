using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Entities.Interfaces
{
	public interface IBelongsTo
	{
	}

	public interface IBelongToApplicationUser : IEntity, IBelongsTo
	{
		int ApplicationUserId { get; set; }
		ApplicationUser ApplicationUser { get; set; }
	}

}
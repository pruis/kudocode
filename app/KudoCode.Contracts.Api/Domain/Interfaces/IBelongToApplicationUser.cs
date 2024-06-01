namespace KudoCode.Contracts.Api
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
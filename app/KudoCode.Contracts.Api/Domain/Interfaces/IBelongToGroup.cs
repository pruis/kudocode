namespace KudoCode.Contracts.Api
{
	public interface IBelongToGroup
	{
		int AuthorizationGroupId { get; set; }
		AuthorizationGroup AuthorizationGroup { get; set; }

	}

}
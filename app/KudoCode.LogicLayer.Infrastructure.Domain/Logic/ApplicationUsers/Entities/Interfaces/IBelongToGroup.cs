namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Entities.Interfaces
{
	public interface IBelongToGroup
	{
		int AuthorizationGroupId { get; set; }
		AuthorizationGroup AuthorizationGroup { get; set; }

	}

}
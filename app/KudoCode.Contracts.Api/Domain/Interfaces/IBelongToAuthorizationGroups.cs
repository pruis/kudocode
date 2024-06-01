using System.Collections.Generic;

namespace KudoCode.Contracts.Api
{
	public interface IBelongToAuthorizationGroups<T> : IEntity, IBelongsTo
		where T : IBelongToGroup
	{
		List<T> AuthorizationGroups { get; set; }
	}

}
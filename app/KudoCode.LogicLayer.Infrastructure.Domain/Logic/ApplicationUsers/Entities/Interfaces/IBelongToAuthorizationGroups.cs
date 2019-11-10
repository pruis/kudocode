using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Entities.Interfaces
{
	public interface IBelongToAuthorizationGroups<T> : IEntity, IBelongsTo
		where T : IBelongToGroup
	{
		List<T> AuthorizationGroups { get; set; }
	}

}
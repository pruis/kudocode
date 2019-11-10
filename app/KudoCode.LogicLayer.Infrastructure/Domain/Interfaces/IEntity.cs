using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Interfaces
{

	public interface IEntity
	{
		[Key]
		int Id { get; set; }
	}

	public interface IMapEntity
	{
	}
}
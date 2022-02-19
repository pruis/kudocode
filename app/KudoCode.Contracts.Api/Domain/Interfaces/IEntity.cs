using System.ComponentModel.DataAnnotations;

namespace KudoCode.Contracts.Api
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
using System;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Interfaces
{
	public interface IEntityBasicAudit : IEntity
	{
		DateTime CreatedDate { get; set; }
		string CreatedBy { get; set; }
		DateTime ModifiedDate { get; set; }
		string ModifiedBy { get; set; }
	}
}
using System;
using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;

namespace KudoCode.LogicLayer.Plugin.EntityAudit.Domain.Logic.EntityAudits.Entities.Interface
{

	public interface IEntityAudit : IEntity
	{

		int ApplicationUserId { get; set; }
		string Entity { get; set; }
		int EntityId { get; set; }
		string CreatedBy { get; set; }
		DateTime CreatedDate { get; set; }

		List<PropertyInformation> PropertyInformation { get; set; }
	}

	public interface IPropertyInformation : IEntity
	{
		string Name { get; set; }
		string Value { get; set; }
		int EntityAuditId { get; set; }
	}
}

using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events.Interfaces;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos.Interfaces;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos
{
	public class CreateEntityAuditEventMessage : CreateEntityAuditDto, IEventMetaData, IEntityAuditEventMessage
	{
	}
}
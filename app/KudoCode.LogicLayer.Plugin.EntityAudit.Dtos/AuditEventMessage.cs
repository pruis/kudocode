using KudoCode.Contracts;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos.Interfaces;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos
{
	public class CreateEntityAuditEventMessage : CreateEntityAuditDto, IEventMetaData, IEntityAuditEventMessage
	{
	}
}
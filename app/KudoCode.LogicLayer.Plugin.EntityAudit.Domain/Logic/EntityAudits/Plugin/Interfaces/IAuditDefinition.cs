namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Plugin.Interfaces
{
	public interface IAuditDefinition<in TEntity>
	{
		object GetAudit(TEntity entity);
	}
}
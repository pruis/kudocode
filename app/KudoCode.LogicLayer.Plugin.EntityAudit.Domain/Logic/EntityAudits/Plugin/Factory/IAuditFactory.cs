using System.Collections.Generic;
using System.Threading.Tasks;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Plugin.Factory
{
	public interface IEntityAuditFactory
	{
		Task<List<PropertyInformationDto>> GetDifference(string nameA, string nameB);
		Task<List<PropertyInformationDto>> Set(string name, object obj);
	}
}
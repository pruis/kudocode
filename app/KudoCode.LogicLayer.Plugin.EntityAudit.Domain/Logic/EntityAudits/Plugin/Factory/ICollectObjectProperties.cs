using System.Collections.Generic;
using KudoCode.LogicLayer.Plugin.EntityAudit.Dtos;

namespace KudoCode.LogicLayer.Plugin.EntityAudit.Domain.Logic.EntityAudits.Plugin.Factory
{
	public interface ICollectObjectProperties
	{
		List<PropertyInformationDto> PropertyInformations { get; set; }
		List<PropertyInformationDto> Get(object obj, string parentName = "");
	}
}
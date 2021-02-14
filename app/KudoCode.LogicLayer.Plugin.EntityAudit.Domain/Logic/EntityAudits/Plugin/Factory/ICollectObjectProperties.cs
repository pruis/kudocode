using System.Collections.Generic;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Plugin.Factory
{
	public interface ICollectObjectProperties
	{
		List<PropertyInformationDto> PropertyInformations { get; set; }
		List<PropertyInformationDto> Get(object obj, string parentName = "");
	}
}
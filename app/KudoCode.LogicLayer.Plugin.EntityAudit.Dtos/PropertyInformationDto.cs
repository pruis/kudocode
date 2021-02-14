using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos.Interfaces;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos
{
	public class PropertyInformationDto : IPropertyInformationDto
	{
		public string Name { get; set; }
		public string Value { get; set; }
	}
}

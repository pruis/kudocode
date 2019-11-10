using KudoCode.LogicLayer.Plugin.EntityAudit.Dtos.Interfaces;

namespace KudoCode.LogicLayer.Plugin.EntityAudit.Dtos
{
	public class PropertyInformationDto : IPropertyInformationDto
	{
		public string Name { get; set; }
		public string Value { get; set; }
	}
}

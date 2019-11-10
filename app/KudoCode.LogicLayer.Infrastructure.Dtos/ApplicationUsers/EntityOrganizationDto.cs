using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers
{
	public class EntityOrganizationDto : IEntityOrganizationDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}

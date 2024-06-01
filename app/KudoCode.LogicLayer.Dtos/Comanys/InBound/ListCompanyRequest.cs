using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.Comanys.Outbound
{
	public class ListCompanyRequest : IApiRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

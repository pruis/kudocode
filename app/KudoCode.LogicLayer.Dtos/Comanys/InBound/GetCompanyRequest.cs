using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.Comanys.Outbound
{
	public class GetCompanyRequest : IApiRequestDto
    {
        public int Id { get; set; }
    }
}

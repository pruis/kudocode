using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.Companys.Outbound
{
	public class DeleteCompanyRequest : IApiRequestDto
    {
        public int Id { get; set; }
    }
}

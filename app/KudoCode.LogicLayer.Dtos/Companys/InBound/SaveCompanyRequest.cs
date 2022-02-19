using KudoCode.Contracts;
using System;

namespace KudoCode.LogicLayer.Dtos.Companys.Outbound
{
	public class SaveCompanyRequest : IApiRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
    }
}

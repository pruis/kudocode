using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.Lookups
{
	public class AddressTypeDto : ILookupDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
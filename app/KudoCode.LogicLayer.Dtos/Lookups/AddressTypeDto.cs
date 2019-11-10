using KudoCode.LogicLayer.Dtos.Lookups;

namespace KudoCode.LogicLayer.Dtos.Lookups
{
    public class AddressTypeDto : ILookupDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
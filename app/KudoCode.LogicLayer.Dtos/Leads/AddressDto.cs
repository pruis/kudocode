using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.Lookups;

namespace KudoCode.LogicLayer.Dtos.Leads
{
	public class AddressDto
	{
		public AddressDto()
		{
			Id = 0;
			Complex = "";
			Street = "";
			Suburb = "";
			City = "";
			Code = "";
			AddressTypeId = 0;
			AddressTypes = new List<LookupResponse>();
		}

		public int Id { get; set; }

		//[RequiredIfAttribute]
		public string Complex { get; set; }
		public string Street { get; set; }
		public string Suburb { get; set; }
		public string City { get; set; }
		public string Code { get; set; }
		public int AddressTypeId { get; set; }

		//lokups
		public List<LookupResponse> AddressTypes { get; set; }


		public string GetAddressDescription => $"{Street} {Suburb} {City}";
	}
}
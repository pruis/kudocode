using KudoCode.LogicLayer.Domain.Logic.Lookups.Entities;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Entities
{
	public class Address : IEntity
	{
		public int Id { get; set; }
		public string Complex { get; set; }
		public string Street { get; set; }
		public string Suburb { get; set; }
		public string City { get; set; }
		public string Code { get; set; }

		public int AddressTypeId { get; set; }
		public AddressType AddressType { get; set; }

	}

}
using KudoCode.Contracts.Api;
using System;


namespace KudoCode.LogicLayer.Domain.Logic.Companys.Entities
{
	public class Company : IEntity
    {
        public Company()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
    }
}

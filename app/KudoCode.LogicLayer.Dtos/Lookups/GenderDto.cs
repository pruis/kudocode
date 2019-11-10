namespace KudoCode.LogicLayer.Dtos.Lookups
{
	public class GenderDto: ILookupDto
	{
		public int Id { get; set; }
		public string Description { get; set; }
	}

	public enum Genders
	{
		Female = 1,
		Male = 2,
		Other = 3
	}


	public class LeadScheduledActivityTypeDto : ILookupDto
	{
		public int Id { get; set; }
		public string Description { get; set; }
	}

	public enum LeadActivityScheduleTypes
	{
		Call = 1,
		WithAdvisor = 2,
	}
}
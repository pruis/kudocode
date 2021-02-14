namespace KudoCode.LogicLayer.Dtos.Lookups
{
	public class CurrentAdvisorDto : ILookupDto
	{
		public int Id { get; set; }
		public string Description { get; set; }
	}

	public enum CurrentAdvisors
	{
		Other = 1,
	}
}
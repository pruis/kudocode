using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Acceptance.Leads
{
	[TestClass]
	public class LeadScheduledActivityTests : InMemoryTest
	{

		[TestMethod]
		public void LeadScheduledActivity_Create()
		{
			this.Start().Authenticate();
			new LeadScheduledActivityCreateBddfy().Create(Connector);
		}
		[TestMethod]
		public void LeadScheduledActivity_Update()
		{
			this.Start().Authenticate();
			new LeadScheduledActivityUpdateBddfy().Update(Connector);
		}
	}
}
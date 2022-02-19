using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Acceptance.Email
{
	[TestClass]
	public class EmailTests : InMemoryTest
	{
		[TestMethod]
		public void Send()
		{
			this.Start().Authenticate();
			new EmailBddfy().Get(Connector);
		}
	}
}
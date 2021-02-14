using KudoCode.Test.Acceptance.Email;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Acceptance.AuditEntity
{
	[TestClass]
	public class AuditEntityTests : InMemoryTest
	{
		[TestMethod]
		public void Create()
		{
			this.Start().Authenticate();
			new AuditEntityBddfy().Get(Connector);
		}
	}
}
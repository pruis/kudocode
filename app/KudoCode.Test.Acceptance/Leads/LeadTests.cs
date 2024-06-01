using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Acceptance.Leads
{
	[TestClass]
	public class LeadTests : InMemoryTest
	{
		[TestMethod]
		public void LeadUpdate()
		{
			this.Start().Authenticate();
			new LeadUpdateBddfy().Update(Connector);
		}

		[TestMethod]
		public void LeadCreate()
		{
			this.Start().Authenticate();
			new LeadCreateBddfy().Create(Connector);
		}

		[TestMethod]
		public void LeadSearch()
		{
			this.Start().Authenticate();
			new LeadsSearchBddfy().Search(Connector);
		}

		[TestMethod]
		public void LeadGetAll()
		{
			this.Start().Authenticate();
			new GetLeadsBddfy().Get(Connector);

			//var tasks = new List<Task>() { };
			//for (int i = 0; i < 1; i++)
			//	tasks.Add( new Task(() => new GetLeadsBddfy().Get(Connector)));

			//Parallel.ForEach(tasks, (task) =>
			//{
			//	task.Start();
			//});

			//Task.WaitAll(tasks.ToArray());
		}
	}
}
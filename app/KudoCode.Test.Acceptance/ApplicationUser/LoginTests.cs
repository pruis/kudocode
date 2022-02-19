using System.Collections.Generic;
using System.Threading.Tasks;
using KudoCode.Test.Acceptance.Leads;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Acceptance.ApplicationUser
{
    [TestClass]
    public class LoginTests : InMemoryTest
    {
        public static int id= 0;
        [TestMethod]
        public void ParallelLogins()
        {
            this.Start().Authenticate();
            var leadId = new LeadCreateBddfy().Create(Connector);

            const int taskCount = 100;
            const int skip = 20;

            var tasks = new List<Task>() { };
            for (int i = 0; i < taskCount; i++)
                tasks.Add(new Task(
                    () => new LoginBddfy().Get(this.GetNewConnector(), $"testB@test{id++}.com", leadId)));
            //tasks.Add(new Task(() => new LoginBddfy().Get(this.GetNewConnector(), $"testB@test{2}.com", leadId)));
            //tasks.Add(new Task(() => new LoginBddfy().Get(this.GetNewConnector(), $"testB@test{3}.com", leadId)));
            //tasks.Add(new Task(() => new LoginBddfy().Get(this.GetNewConnector(), $"testB@test{4}.com", leadId)));

            for (int i = 0; i < taskCount; i += skip)
            {
                var range = tasks.GetRange(i, skip);
                Parallel.ForEach(range, a => a.Start());
                Task.WaitAll(range.ToArray());
            }
        }
    }
}
using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.Contracts;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.Leads.GetLead
{
	[TestClass]
    public class WorkerHandlerUnitTest : UnitTestBase
    {
        private GetApplicationUserDto _getApplicationUserDto;
        private IWorkerContext<ApplicationUserDto> _getResponse;

        [TestMethod]
        public void GetApplicationUser()
        {
            base.Run(
                "GetApplicationUserDto WorkerHandler",
                "Given ",
                "When ",
                "Then ");
        }

        protected override void Seed()
        {
            SeedDataBase.InitializeDataBase();
        }

        protected override void Given()
        {
            _getApplicationUserDto = new GetApplicationUserDto("testB@testC.com");
        }

        protected override void When()
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope(ScopeKey))
                _getResponse = scope
                    .Resolve<IHandler<GetApplicationUserDto, IWorkerContext<ApplicationUserDto>>>()
                    .Handle(_getApplicationUserDto);
        }

        protected override void Then()
        {
            Assert.IsNotNull(_getResponse);
            Assert.IsFalse(
                _getResponse.Messages.Any(a => a.Type == MessageDtoType.Error));
            Assert.IsTrue(_getResponse.Result.Email.Equals("testB@testC.com"),
                "result application user email != request application user email");
        }
    }
}
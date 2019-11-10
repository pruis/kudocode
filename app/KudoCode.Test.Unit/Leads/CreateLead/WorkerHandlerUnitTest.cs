using System.Linq;
using Autofac;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.LogicLayer.Plugin.EntityAudit.Dtos;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.Leads.CreateLead
{
    [TestClass]
    public class WorkerHandlerUnitTest : UnitTestBase
    {
        private CreateLeadRequest _newLeadRequest;
        private IWorkerContext<int> _saveResonse;

        public WorkerHandlerUnitTest()
        {
        }

        [TestMethod]
        public void CreateLead()
        {
            base.Run(
                "CreateLeadDto WorkerHandler",
                "Given a CreateLeadDto",
                "when I call CreateLeadDtoWorkerHandler",
                "Then I receive an ID with no error messages");
        }

        protected override void Seed()
        {
            SeedDataBase.InitializeDataBase();
        }

        protected override void Given()
        {
            _newLeadRequest = new CreateLeadRequest()
            {
                LeadPersonalInformation = new LeadPersonalInformationDto()
                {
                    FirstName = "test",
                    Surname = "test",
                    Email = $"{TestHelpers.UniqueName()}B@test.com",
                    CurrentAdvisorId = 1,
                    GenderId = 1,
                    OccupationId = 1
                },
            };
        }

        protected override void When()
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope(ScopeKey))
            {
                _saveResonse = scope
                    .Resolve<IHandler<CreateLeadRequest, IWorkerContext<int>>>()
                    .Handle(_newLeadRequest);
            }
        }

        protected override void Then()
        {
            Assert.IsTrue(_saveResonse.Result > 0);
            Assert.IsTrue(!_saveResonse.HasErrors());
            Assert.IsTrue((_saveResonse.Events[0] as EventRequestDto<CreateEntityAuditEventMessage>)
                .MetaData
                .Entity
                .Equals("Lead"));
        }
    }
}
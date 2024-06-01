using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.Leads.GetLead
{
	[TestClass]
    public class ExecutionPipelineHandlersUnitTest : UnitTestBase
    {
        private int _leadId;
        private GetLeadRequest _getLeadRequest;
        private IApiResponseContextDto<GetLeadResponse> _getResponse;

        public ExecutionPipelineHandlersUnitTest()
        {
        }

        [TestMethod]
        public void GetLead()
        {
            base.Run(
                "GetLeadDto ExecutionPipelineHandlers",
                "Given an ExecutionPipelineHandlers",
                "When I call the ExecutionPipeline with GetLeadDto",
                "Then i receive a result with no error messages and a result");
        }

        protected override void Seed()
        {
            SeedDataBase.InitializeDataBase();
            _leadId = SeedDataBase.CreateLead($"test{TestHelpers.UniqueName()}B@testC.com");
        }

        protected override void Given()
        {
            _getLeadRequest = new GetLeadRequest() {Id = _leadId};
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<ExecutionPipelineHandlers>()
                .Execute<GetLeadRequest, GetLeadResponse>(_getLeadRequest);
        }

        protected override void Then()
        {
            Assert.IsNotNull(_getResponse.Result);
            Assert.IsFalse(
                _getResponse.Messages.Any(a => a.Type == MessageDtoType.Error));
        }
    }
}
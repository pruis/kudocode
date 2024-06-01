//using System.Linq;
//using Autofac;
//using KudoCode.Helpers;
//using KudoCode.LogicLayer.Dtos.Leads;
//using KudoCode.LogicLayer.Dtos.Leads.GetLead;
//using KudoCode.Contracts.Api;
//using KudoCode.Contracts.Response.Interfaces;
//using KudoCode.LogicLayer.Infrastructure.Execution.Interfaces;
//using KudoCode.Test.Unit.InMemoryDataBase;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//
//namespace KudoCode.Test.Unit.Leads.GetLead
//{
//    [TestClass]
//    public class ExecutionPipelineUnitTest : UnitTestBase
//    {
//        private int _leadId;
//        private GetLeadDto _getLeadDto;
//        private IApiResponseContextDto<LeadDto> _getResponse;
//
//        [TestMethod]
//        public void GetLead()
//        {
//            base.Run(
//                "GetLeadDto ExecutionPipeline",
//                "Given a lead",
//                "When I call the ExecutionPipeline with GetLeadDto",
//                "Then i receive a result with no error messages");
//        }
//
//        protected override void Seed()
//        {
//            SeedDataBase.InitializeDataBase();
//            _leadId = SeedDataBase.CreateLead($"test{TestHelpers.UniqueName()}B@testC.com");
//        }
//
//        protected override void Given()
//        {
//            _getLeadDto = new GetLeadDto() {Id = _leadId};
//        }
//
//        protected override void When()
//        {
//            _getResponse = ApplicationContext
//                .Container
//                .Resolve<IExecutionPipeline>()
//                .Execute<GetLeadDto, LeadDto>(_getLeadDto);
//        }
//
//        protected override void Then()
//        {
//            Assert.IsNotNull(_getResponse.Result);
//            Assert.IsFalse(
//                _getResponse.Messages.Any(a => a.Type == LogicLayer.Infrastructure.Dtos.MessageDtoType.Error));
//        }
//    }
//}
using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.Leads.GetLead
{
	[TestClass]
    public class ValidationUnitTest_Fail : UnitTestBase
    {
        private int _leadId;
        private GetLeadRequest _getLeadRequest;
        private IValidationContext<GetLeadResponse> _getResponse;

        public ValidationUnitTest_Fail()
        {
        }

        [TestMethod]
        public void GetLeadDtoValidation()
        {
            base.Run(
                "GetLeadDto Validation - FAIL",
                "Given a invalid GetLeadDto",
                "When I vaildate the dto",
                "Then I receive error messages");
        }

        protected override void Seed()
        {
            _leadId = 0;
        }

        protected override void Given()
        {
            _getLeadRequest = new GetLeadRequest() {Id = _leadId};
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetLeadRequest, IValidationContext<GetLeadResponse>>>()
                .Handle(_getLeadRequest);
        }

        protected override void Then()
        {
            Assert.IsTrue(_getResponse.Messages.Count() == 1);
            Assert.IsTrue(_getResponse.Messages.Any(a => a.Key == "E6"), _getResponse.Messages[0].Message);
        }
    }
}
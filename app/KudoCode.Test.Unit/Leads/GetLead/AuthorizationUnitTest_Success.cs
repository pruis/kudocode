using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.Leads.GetLead
{
	[TestClass]
    public class AuthorizationUnitTest_Success : UnitTestBase
    {
        private int _leadId;
        private GetLeadRequest _getLeadRequest;
        private IAuthorizationContext<GetLeadResponse> _getResponse;

        public AuthorizationUnitTest_Success()
        {
        }

        [TestMethod]
        public void GetLeadDtoAuthorization()
        {
            base.Run(
                "GetLeadDto Authorization - SUCCESS",
                "Given a user with group A access and Admin Role",
                "When I Authorization the dto",
                "Then I receive no error messages");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            _getLeadRequest = new GetLeadRequest() {Id = _leadId};
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetLeadRequest, IAuthorizationContext<GetLeadResponse>>>()
                .Handle(_getLeadRequest);
        }

        protected override void Then()
        {
            Assert.IsTrue(_getResponse.Messages.Count() == 0);
        }
    }
}
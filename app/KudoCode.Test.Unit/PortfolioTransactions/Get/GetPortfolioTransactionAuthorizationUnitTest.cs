using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound;
using KudoCode.Contracts;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.PortfolioTransactions.Get
{
	[TestClass]
    public class GetPortfolioTransactionAuthorizationUnitTest : UnitTestBase
    {
        private GetPortfolioTransactionRequest _request;
        private IAuthorizationContext<GetPortfolioTransactionResponse> _getResponse;

        public GetPortfolioTransactionAuthorizationUnitTest()
        {
        }

        [TestMethod]
        public void GetPortfolioTransactionRequestAuthorization()
        {
            base.Run(
                "GetPortfolioTransactionRequest Authorization",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
            ApplicationContext.Container.Resolve<IApplicationUserContext>().Token.IsValidTokenProvided = true;
        }

        protected override void Given()
        {
            _request = new GetPortfolioTransactionRequest() { };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetPortfolioTransactionRequest, IAuthorizationContext<GetPortfolioTransactionResponse>
                >>()
                .Handle(_request);
        }

        protected override void Then()
        {
            //Assert.IsTrue(false);
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));
        }
    }
}
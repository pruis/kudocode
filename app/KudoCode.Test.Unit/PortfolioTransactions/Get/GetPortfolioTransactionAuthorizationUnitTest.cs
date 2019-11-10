using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            ApplicationContext.Container.Resolve<IAuthenticationContext<GetPortfolioTransactionResponse>>().IsValidTokenProvided = true;
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
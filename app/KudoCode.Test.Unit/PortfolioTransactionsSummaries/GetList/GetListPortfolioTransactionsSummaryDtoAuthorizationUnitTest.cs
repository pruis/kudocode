using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.Contracts;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.PortfolioTransactionsSummaries.GetList
{
    [TestClass]
    public class GetListPortfolioTransactionsSummaryAuthorizationUnitTest : UnitTestBase
    {
        private GetListPortfolioTransactionsSummaryRequest _request;
        private IAuthorizationContext<GetListPortfolioTransactionsSummaryResponse> _getResponse;

        [TestMethod]
        public void GetListPortfolioTransactionsSummaryDtoAuthorization()
        {
            base.Run(
                "GetListPortfolioTransactionsSummaryDto Authorization",
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
            _request = new GetListPortfolioTransactionsSummaryRequest() { };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetListPortfolioTransactionsSummaryRequest,
                    IAuthorizationContext<GetListPortfolioTransactionsSummaryResponse>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));
        }
    }
}
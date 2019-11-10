using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            ApplicationContext.Container.Resolve<IAuthenticationContext<GetListPortfolioTransactionsSummaryResponse>>().IsValidTokenProvided = true;

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
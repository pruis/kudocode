using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.PortfolioTransactionsSummaries.Get
{
	[TestClass]
    public class GetPortfolioTransactionsSummaryValidationUnitTest : UnitTestBase
    {
        private GetPortfolioTransactionsSummaryRequest _request;
        private IValidationContext<GetPortfolioTransactionsSummaryResponse> _getResponse;

        public GetPortfolioTransactionsSummaryValidationUnitTest()
        {
        }

        [TestMethod]
        public void GetPortfolioTransactionsSummaryRequestValidation()
        {
            base.Run(
                "GetPortfolioTransactionsSummaryRequest Validation",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            _request = new GetPortfolioTransactionsSummaryRequest() { };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetPortfolioTransactionsSummaryRequest,
                    IValidationContext<GetPortfolioTransactionsSummaryResponse>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsTrue(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));

            Assert.IsTrue(_getResponse.Messages.Any(a =>
                a.Key == "E6"));

            Assert.IsTrue(_getResponse.Messages.Any(a =>
                a.Message.Contains("Summary Id")));
        }
    }
}
using System;
using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.PortfolioTransactionsSummaries.Get
{
    [TestClass]
    public class GetPortfolioTransactionsSummaryWorkerUnitTest : UnitTestBase
    {
        private GetPortfolioTransactionsSummaryRequest _request;
        private IWorkerContext<GetPortfolioTransactionsSummaryResponse> _getResponse;
        private int _portfolioId;
        private int _summaryId;

        public GetPortfolioTransactionsSummaryWorkerUnitTest()
        {
        }

        [TestMethod]
        public void GetPortfolioTransactionsSummaryRequestWorker()
        {
            base.Run(
                "GetPortfolioTransactionsSummaryRequest Worker",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
            _portfolioId = SeedDataBase.CreatePortfolio("test",DateTime.Now);
            _summaryId = SeedDataBase.CreatePortfolioTransactionSummary(_portfolioId);
        }

        protected override void Given()
        {
            _request = new GetPortfolioTransactionsSummaryRequest() {SummaryId = _summaryId};
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetPortfolioTransactionsSummaryRequest,
                    IWorkerContext<GetPortfolioTransactionsSummaryResponse>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));

            Assert.IsTrue(_getResponse.Result != null);
        }
    }
}
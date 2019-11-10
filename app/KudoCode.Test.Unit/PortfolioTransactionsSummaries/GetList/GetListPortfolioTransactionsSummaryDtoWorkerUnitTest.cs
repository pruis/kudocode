using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.PortfolioTransactionsSummaries.GetList
{
    [TestClass]
    public class GetListPortfolioTransactionsSummaryWorkerUnitTest : UnitTestBase
    {
        private GetListPortfolioTransactionsSummaryRequest _request;
        private IWorkerContext<GetListPortfolioTransactionsSummaryResponse> _getResponse;
        private int _summaryId;
        private int _portfolioId;

        [TestMethod]
        public void GetListPortfolioTransactionsSummaryDtoWorker()
        {
            base.Run(
                "GetListPortfolioTransactionsSummaryDto Worker",
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
            _request = new GetListPortfolioTransactionsSummaryRequest() {PortfolioId = _portfolioId};
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetListPortfolioTransactionsSummaryRequest,
                    IWorkerContext<GetListPortfolioTransactionsSummaryResponse>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));

            Assert.IsTrue(_getResponse.Result.PortfolioTransactionsSummaries.Any());
        }
    }
}
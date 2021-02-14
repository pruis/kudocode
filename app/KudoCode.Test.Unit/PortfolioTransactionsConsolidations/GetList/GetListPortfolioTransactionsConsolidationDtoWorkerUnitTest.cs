using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Outbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.PortfolioTransactionsConsolidations.GetList
{
    [TestClass]
    public class GetListPortfolioTransactionsConsolidationWorkerUnitTest : UnitTestBase
    {
        private GetListPortfolioTransactionsConsolidationDto _dto;
        private IWorkerContext<List<PortfolioTransactionsConsolidationDto>> _getResponse;
        private int _summaryId;

        public GetListPortfolioTransactionsConsolidationWorkerUnitTest()
        {
        }

        [TestMethod]
        public void GetListPortfolioTransactionsConsolidationDtoWorker()
        {
            base.Run(
                "GetListPortfolioTransactionsConsolidationDto Worker",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
            var portfolioId = SeedDataBase.CreatePortfolio("test",DateTime.Now);
            _summaryId = SeedDataBase.CreatePortfolioTransactionSummary(portfolioId);
            SeedDataBase.CreatePortfolioTransactionsConsolidation(_summaryId);
        }

        protected override void Given()
        {
            _dto = new GetListPortfolioTransactionsConsolidationDto() {PortfolioTransactionsSummaryId = _summaryId};
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetListPortfolioTransactionsConsolidationDto,
                    IWorkerContext<List<PortfolioTransactionsConsolidationDto>>>>()
                .Handle(_dto);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));

            Assert.IsTrue(_getResponse.Result.Any());
        }
    }
}
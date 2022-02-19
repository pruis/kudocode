using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Inbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Inbound;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace KudoCode.Test.Unit.PortfolioTransactionsConsolidations.Save
{
	[TestClass]
    public class SavePortfolioTransactionsConsolidationWorkerUnitTest : UnitTestBase
    {
        private SavePortfolioTransactionsConsolidationDto _dto;
        private IWorkerContext<int> _getResponse;
        private int _summaryId;

        [TestMethod]
        public void SavePortfolioTransactionsConsolidationDtoWorker()
        {
            base.Run(
                "SavePortfolioTransactionsConsolidationDto Worker",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope(Guid.NewGuid().ToString()))
            {
                var summaryDto = new SavePortfolioTransactionsSummaryRequest()
                {
                    PortfolioName = "Test",
                    CloseAmount = 10,
                    OpenAmount = 11,
                    CloseDate = DateTime.Now.ToString(),
                    OpenDate = DateTime.Now.AddDays(-21).ToString(),
                };

                var portfolioResponse = ApplicationContext
                    .Container
                    .Resolve<IHandler<SavePortfolioRequest, IWorkerContext<int>>>()
                    .Handle(new SavePortfolioRequest() {Name = "Test"});

                var portfolioTransactionsSummaryResponse = ApplicationContext
                    .Container
                    .Resolve<IHandler<SavePortfolioTransactionsSummaryRequest, IWorkerContext<int>>>()
                    .Handle(summaryDto);

                Assert.IsFalse(portfolioResponse.HasErrors());
                Assert.IsFalse(portfolioTransactionsSummaryResponse.HasErrors());

                _summaryId = portfolioTransactionsSummaryResponse.Result;
            }
        }

        protected override void Given()
        {
            _dto = new SavePortfolioTransactionsConsolidationDto() {PortfolioTransactionsSummaryId = _summaryId};
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<SavePortfolioTransactionsConsolidationDto, IWorkerContext<int>>>()
                .Handle(_dto);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));

            Assert.IsTrue(_getResponse.Result > 0);
        }
    }
}
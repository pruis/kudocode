using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Inbound;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace KudoCode.Test.Unit.PortfolioTransactionsSummaries.Save
{
	[TestClass]
    public class SavePortfolioTransactionsSummaryWorkerUnitTest : UnitTestBase
    {
        private SavePortfolioTransactionsSummaryRequest _request;
        private IWorkerContext<int> _getResponse;

        [TestMethod]
        public void SavePortfolioTransactionsSummaryDtoWorker()
        {
            base.Run(
                "SavePortfolioTransactionsSummaryDto Worker - Duplicate Check",
                "Given a portfolio and saved summary",
                "When I save a new summary with the same detail",
                "I get an a duplication error");
        }

        protected override void Seed()
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope(Guid.NewGuid().ToString()))
            {
                _request = new SavePortfolioTransactionsSummaryRequest()
                {
                    PortfolioName = "Test",
                    CloseAmount = 10,
                    OpenAmount = 11,
                    OpenDate = DateTime.Now.AddDays(-21).ToString(DateFormat),
                    CloseDate = DateTime.Now.ToString(DateFormat),
                };

                var portfolioResponse = ApplicationContext
                    .Container
                    .Resolve<IHandler<SavePortfolioRequest, IWorkerContext<int>>>()
                    .Handle(new SavePortfolioRequest() {Name = "Test"});

                var portfolioTransactionsSummaryResponse = ApplicationContext
                    .Container
                    .Resolve<IHandler<SavePortfolioTransactionsSummaryRequest, IWorkerContext<int>>>()
                    .Handle(_request);

                Assert.IsFalse(portfolioResponse.HasErrors());
                Assert.IsFalse(portfolioTransactionsSummaryResponse.HasErrors());
            }
        }

        protected override void Given()
        {
        }

        protected override void When()
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope(Guid.NewGuid().ToString()))
                _getResponse = ApplicationContext
                    .Container
                    .Resolve<IHandler<SavePortfolioTransactionsSummaryRequest, IWorkerContext<int>>>()
                    .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsTrue(_getResponse.HasErrors());
            Assert.IsTrue(_getResponse.Messages.Any(a => a.Message.Contains("Input validation: Duplicate PortfolioTransactionsSummary")));
        }
    }
}
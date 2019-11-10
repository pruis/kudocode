using System;
using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Inbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.PortfolioTransactionsSummaries.Save
{
    [TestClass]
    public class SavePortfolioTransactionsSummaryDtoWorkerUnitTestUpdate : UnitTestBase
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
                    CloseDate = DateTime.Now.ToString(DateFormat),
                    OpenDate = DateTime.Now.AddDays(-21).ToString(DateFormat),
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

                _request.Id = portfolioTransactionsSummaryResponse.Result;
                _request.CloseAmount = 111;
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
            Assert.IsFalse(_getResponse.HasErrors());
        }
    }
}
using System;
using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Inbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.PortfolioTransactionsSummaries.Save
{
    [TestClass]
    public class SavePortfolioTransactionsSummaryDtoWorkerUnitTest_not_found_portfolio : UnitTestBase
    {
        private SavePortfolioTransactionsSummaryRequest _request;
        private IWorkerContext<int> _getResponse;

        [TestMethod]
        public void SavePortfolioTransactionsSummaryDtoWorker()
        {
            base.Run(
                "SavePortfolioTransactionsSummaryDto Worker - Portfolio not found",
                "Given a summary with an invalid portfolio",
                "When I save",
                "Then i get a portfolio not found error");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            _request = new SavePortfolioTransactionsSummaryRequest()
            {
                PortfolioName = "Test",
                CloseAmount = 10,
                OpenAmount = 11,
                CloseDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm"),
                OpenDate = DateTime.Now.AddDays(-21).ToString("dd-MM-yyyy HH:mm"),
            };
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
            Assert.IsTrue(_getResponse.Messages.Any(a =>
                a.Message.Contains("Portfolio not found")));
        }
    }
}
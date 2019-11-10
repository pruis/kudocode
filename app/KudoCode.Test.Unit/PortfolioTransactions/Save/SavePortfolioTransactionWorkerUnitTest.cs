using System;
using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Inbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.PortfolioTransactions.Save
{
    [TestClass]
    public class SavePortfolioTransactionWorkerUnitTest : UnitTestBase
    {
        private SavePortfolioTransactionRequest _request;
        private IWorkerContext<int> _getResponse;
        private int _portfolioId;

        public SavePortfolioTransactionWorkerUnitTest()
        {
        }

        [TestMethod]
        public void SavePortfolioTransactionRequestWorker()
        {
            base.Run(
                "SavePortfolioTransactionRequest Worker",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
            _portfolioId = SeedDataBase.CreatePortfolio("test", new DateTime());
            _portfolioId = SeedDataBase.CreatePortfolioShare("test");
            _portfolioId = SeedDataBase.CreatePortfolioTransactionType("test");
        }

        protected override void Given()
        {
            _request = new SavePortfolioTransactionRequest()
            {
                PortfolioId = _portfolioId,
                Date = DateTime.Now.ToString(),
                Price = 11.4m,
                Quantity = 2342,
                PortfolioShareId = 1,
                PortfolioTransactionTypeId = 1,
                Total = 434,
            };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<SavePortfolioTransactionRequest, IWorkerContext<int>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));
        }
    }
}
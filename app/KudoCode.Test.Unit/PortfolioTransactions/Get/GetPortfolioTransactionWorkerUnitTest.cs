using System;
using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.PortfolioTransactions.Get
{
    [TestClass]
    public class GetPortfolioTransactionWorkerUnitTest : UnitTestBase
    {
        private GetPortfolioTransactionRequest _request;
        private IWorkerContext<GetPortfolioTransactionResponse> _getResponse;
        private string _name;
        private int _portfolioId;
        private int _portfolioTransactionId;

        public GetPortfolioTransactionWorkerUnitTest()
        {
        }

        [TestMethod]
        public void GetPortfolioTransactionRequestWorker()
        {
            base.Run(
                "GetPortfolioTransactionRequest Worker",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
            _name = "test portfolio";
            _portfolioId = SeedDataBase.CreatePortfolio(_name, DateTime.Now);
            var x = SeedDataBase.CreatePortfolioShare("ABC");
            var y = SeedDataBase.CreatePortfolioTransactionType("Close");
            _portfolioTransactionId = SeedDataBase.GetPortfolioTransaction(_portfolioId);
        }

        protected override void Given()
        {
            _request = new GetPortfolioTransactionRequest() {Id = _portfolioTransactionId, PortfolioId = _portfolioId};
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetPortfolioTransactionRequest, IWorkerContext<GetPortfolioTransactionResponse>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));
            Assert.IsTrue(_getResponse.Result.Id > 0);
        }
    }
}
using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static KudoCode.Contracts.MessageDtoType;

namespace KudoCode.Test.Unit.Portfolios.GetPortfolio
{
	[TestClass]
    public class GetPortfolioWorkerUnitTest : UnitTestBase
    {
        private GetPortfolioRequest _request;
        private IWorkerContext<GetPortfolioResponse> _getResponse;
        private string _name;
        private int _portfolioId;
        private int _portfolioTransactionSummaryId;
        private string _openDate;

        public GetPortfolioWorkerUnitTest()
        {
        }

        [TestMethod]
        public void GetPortfolioDtoWorker()
        {
            base.Run(
                "GetPortfolioDto Worker",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
            var openDate = DateTime.Now;
            _openDate = openDate.ToString(DateFormat);

            _name = "test portfolio";
            _portfolioId = SeedDataBase.CreatePortfolio(_name, openDate);
            _portfolioTransactionSummaryId = SeedDataBase.CreatePortfolioTransactionSummary(_portfolioId);
        }

        protected override void Given()
        {
            _request = new GetPortfolioRequest() {Id = _portfolioId};
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetPortfolioRequest, IWorkerContext<GetPortfolioResponse>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == Error));

            Assert.IsTrue(_getResponse.Result.Name.Equals(_name));
            Assert.IsTrue(_getResponse.Result.OpenDate.Equals(_openDate));
            Assert.IsTrue(_getResponse.Result.TransactionsSummaries.Any());
        }
    }
}
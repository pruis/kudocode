using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Contracts;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace KudoCode.Test.Unit.Portfolios.GetList
{
	[TestClass]
    public class GetListPortfolioWorkerUnitTest : UnitTestBase
    {
        private GetListPortfolioRequest _request;
        private IWorkerContext<GetListPortfolioResponse> _getResponse;

        public GetListPortfolioWorkerUnitTest()
        {
        }

        [TestMethod]
        public void GetListPortfolioDtoWorker()
        {
            base.Run(
                "GetListPortfolioDto Worker",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
            SeedDataBase.CreatePortfolio("test portfolio 1", DateTime.Now);
            SeedDataBase.CreatePortfolio("test portfolio 2", DateTime.Now);
            SeedDataBase.CreatePortfolio("test portfolio 3", DateTime.Now);
        }

        protected override void Given()
        {
            _request = new GetListPortfolioRequest() { };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetListPortfolioRequest, IWorkerContext<GetListPortfolioResponse>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));

            Assert.IsTrue(_getResponse.Result.Portfolios.Count > 0);
        }
    }
}
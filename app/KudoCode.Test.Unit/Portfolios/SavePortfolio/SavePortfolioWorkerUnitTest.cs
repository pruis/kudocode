using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using KudoCode.Contracts;

namespace KudoCode.Test.Unit.Portfolios.SavePortfolio
{
	[TestClass]
    public class SavePortfolioWorkerUnitTest : UnitTestBase
    {
        private SavePortfolioRequest _request;
        private IWorkerContext<int> _getResponse;
        private string _date;

        public SavePortfolioWorkerUnitTest()
        {
        }

        [TestMethod]
        public void SavePortfolioDtoWorker()
        {
            base.Run(
                "SavePortfolioDto Worker",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            _date = DateTime.Today.ToString(DateFormat);
            _request = new SavePortfolioRequest()
            {
                Id = 0,
                Name = "test",
                OpenDate = _date
            };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<SavePortfolioRequest, IWorkerContext<int>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));

            Assert.IsTrue(_getResponse.Result > 0);
        }
    }
}
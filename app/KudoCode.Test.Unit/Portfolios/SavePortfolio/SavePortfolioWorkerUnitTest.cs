using System;
using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.OpenXmlFormats.Dml.Chart;
using static KudoCode.LogicLayer.Infrastructure.Dtos.Messages.MessageDtoType;

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
                a.Type == Error));

            Assert.IsTrue(_getResponse.Result > 0);
        }
    }
}
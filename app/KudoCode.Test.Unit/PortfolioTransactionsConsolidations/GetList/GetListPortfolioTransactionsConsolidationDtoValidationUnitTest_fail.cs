using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Outbound;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.Test.Unit.PortfolioTransactionsConsolidations.GetList
{
    [TestClass]
    public class GetListPortfolioTransactionsConsolidationValidationUnitTest : UnitTestBase
    {
        private GetListPortfolioTransactionsConsolidationDto _dto;
        private IValidationContext<List<PortfolioTransactionsConsolidationDto>> _getResponse;

        [TestMethod]
        public void GetListPortfolioTransactionsConsolidationDtoValidation()
        {
            base.Run(
                "GetListPortfolioTransactionsConsolidationDto Validation",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            _dto = new GetListPortfolioTransactionsConsolidationDto() { };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetListPortfolioTransactionsConsolidationDto,
                    IValidationContext<List<PortfolioTransactionsConsolidationDto>>>>()
                .Handle(_dto);
        }

        protected override void Then()
        {
            Assert.IsTrue(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));

            Assert.IsTrue(_getResponse.Messages.Any(a =>
                a.Key == "E6"));

            Assert.IsTrue(_getResponse.Messages.Any(a =>
                a.Message.Contains("Portfolio Transactions Summary Id")));
        }
    }
}
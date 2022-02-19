using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Outbound;
using KudoCode.Contracts;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.Test.Unit.PortfolioTransactionsConsolidations.GetList
{
	[TestClass]
    public class GetListPortfolioTransactionsConsolidationAuthorizationUnitTest : UnitTestBase
    {
        private GetListPortfolioTransactionsConsolidationDto _dto;
        private IAuthorizationContext<List<PortfolioTransactionsConsolidationDto>> _getResponse;

        public GetListPortfolioTransactionsConsolidationAuthorizationUnitTest()
        {
        }

        [TestMethod]
        public void GetListPortfolioTransactionsConsolidationDtoAuthorization()
        {
            base.Run(
                "GetListPortfolioTransactionsConsolidationDto Authorization",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
            ApplicationContext.Container.Resolve<IApplicationUserContext>().Token.IsValidTokenProvided = true;
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
                    IAuthorizationContext<List<PortfolioTransactionsConsolidationDto>>>>()
                .Handle(_dto);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));
        }
    }
}
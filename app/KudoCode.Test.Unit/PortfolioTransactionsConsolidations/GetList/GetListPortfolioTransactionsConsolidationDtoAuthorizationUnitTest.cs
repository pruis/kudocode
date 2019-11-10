using System.Collections.Generic;
using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Outbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            ApplicationContext.Container.Resolve<IAuthenticationContext<List<PortfolioTransactionsConsolidationDto>>>().IsValidTokenProvided = true;
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
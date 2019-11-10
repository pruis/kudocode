using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Inbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.PortfolioTransactionsConsolidations.Save
{
    [TestClass]
    public class SavePortfolioTransactionsConsolidationAuthorizationUnitTest : UnitTestBase
    {
        private SavePortfolioTransactionsConsolidationDto _dto;
        private IAuthorizationContext<int> _getResponse;

        [TestMethod]
        public void SavePortfolioTransactionsConsolidationDtoAuthorization()
        {
            base.Run(
                "SavePortfolioTransactionsConsolidationDto Authorization",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
            ApplicationContext.Container.Resolve<IAuthenticationContext<int>>()
                .IsValidTokenProvided = true;

        }

        protected override void Given()
        {
            _dto = new SavePortfolioTransactionsConsolidationDto() { };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<SavePortfolioTransactionsConsolidationDto, IAuthorizationContext<int>>>()
                .Handle(_dto);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));
        }
    }
}
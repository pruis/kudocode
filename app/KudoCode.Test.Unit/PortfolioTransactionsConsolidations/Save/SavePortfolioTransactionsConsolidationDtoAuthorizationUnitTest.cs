using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Inbound;
using KudoCode.Contracts;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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
            ApplicationContext.Container.Resolve<IApplicationUserContext>().Token.IsValidTokenProvided = true;

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
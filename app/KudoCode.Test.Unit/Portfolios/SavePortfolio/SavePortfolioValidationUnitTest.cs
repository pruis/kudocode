using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using static KudoCode.Contracts.MessageDtoType;

namespace KudoCode.Test.Unit.Portfolios.SavePortfolio
{
	[TestClass]
    public class SavePortfolioValidationUnitTest : UnitTestBase
    {
        private SavePortfolioRequest _request;
        private IValidationContext<int> _getResponse;

        public SavePortfolioValidationUnitTest()
        {
        }

        [TestMethod]
        public void SavePortfolioDtoValidation()
        {
            base.Run(
                "SavePortfolioDto Validation",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            _request = new SavePortfolioRequest() {Name = "test"};
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<SavePortfolioRequest, IValidationContext<int>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == Error));
        }
    }
}
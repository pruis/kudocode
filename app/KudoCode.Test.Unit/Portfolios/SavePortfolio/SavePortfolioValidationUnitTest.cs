using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.Test.Unit.AutoFacModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KudoCode.LogicLayer.Infrastructure.Dtos.Messages.MessageDtoType;

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
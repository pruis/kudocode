using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KudoCode.LogicLayer.Infrastructure.Dtos.Messages.MessageDtoType;

namespace KudoCode.Test.Unit.Portfolios.GetPortfolio
{
    [TestClass]
    public class GetPortfolioValidationUnitTest : UnitTestBase
    {
        private GetPortfolioRequest _request;
        private IValidationContext<GetPortfolioResponse> _getResponse;

        public GetPortfolioValidationUnitTest()
        {
        }

        [TestMethod]
        public void GetPortfolioDtoValidation()
        {
            base.Run(
                "GetPortfolioDto Validation",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            _request = new GetPortfolioRequest() { Id = 1};
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetPortfolioRequest, IValidationContext<GetPortfolioResponse>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == Error));
        }
    }
}
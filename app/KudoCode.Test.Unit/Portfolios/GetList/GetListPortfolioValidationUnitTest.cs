using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.Portfolios.GetList
{
	[TestClass]
    public class GetListPortfolioValidationUnitTest : UnitTestBase
    {
        private GetListPortfolioRequest _request;
        private IValidationContext<GetListPortfolioResponse> _getResponse;

        [TestMethod]
        public void GetListPortfolioDtoValidation()
        {
            base.Run(
                "GetListPortfolioDto Validation",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            _request = new GetListPortfolioRequest() { };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetListPortfolioRequest, IValidationContext<GetListPortfolioResponse>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));
        }
    }
}
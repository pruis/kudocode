using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using KudoCode.Contracts;

namespace KudoCode.Test.Unit.Portfolios.GetPortfolio
{
	[TestClass]
    public class GetPortfolioAuthorizationUnitTest : UnitTestBase
    {
        private GetPortfolioRequest _request;
        private IAuthorizationContext<GetPortfolioResponse> _getResponse;

        public GetPortfolioAuthorizationUnitTest()
        {
        }

        [TestMethod]
        public void GetPortfolioDtoAuthorization()
        {
            base.Run(
                "GetPortfolioDto Authorization",
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
            _request = new GetPortfolioRequest() { };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetPortfolioRequest, IAuthorizationContext<GetPortfolioResponse>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));
        }
    }
}
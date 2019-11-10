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
            ApplicationContext.Container.Resolve<IAuthenticationContext<GetPortfolioResponse>>().IsValidTokenProvided = true;
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
                a.Type == Error));
        }
    }
}
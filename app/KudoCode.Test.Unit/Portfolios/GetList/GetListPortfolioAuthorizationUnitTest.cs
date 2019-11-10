using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.Portfolios.GetList
{
    [TestClass]
    public class GetListPortfolioAuthorizationUnitTest : UnitTestBase
    {
        private GetListPortfolioRequest _request;
        private IAuthorizationContext<GetListPortfolioResponse> _getResponse;

        [TestMethod]
        public void GetListPortfolioDtoAuthorization()
        {
            base.Run(
                "GetListPortfolioDto Authorization",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
            ApplicationContext.Container.Resolve<IAuthenticationContext<GetListPortfolioResponse>>().IsValidTokenProvided = true;
        }

        protected override void Given()
        {
            _request = new GetListPortfolioRequest() { };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<GetListPortfolioRequest, IAuthorizationContext<GetListPortfolioResponse>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));
        }
    }
}
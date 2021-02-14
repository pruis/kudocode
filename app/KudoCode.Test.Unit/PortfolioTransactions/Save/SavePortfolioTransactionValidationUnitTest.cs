using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Inbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.PortfolioTransactions.Save
{
    [TestClass]
    public class SavePortfolioTransactionValidationUnitTest : UnitTestBase
    {
        private SavePortfolioTransactionRequest _request;
        private IValidationContext<int> _getResponse;

        [TestMethod]
        public void SavePortfolioTransactionRequestValidation()
        {
            base.Run(
                "SavePortfolioTransactionRequest Validation",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            _request = new SavePortfolioTransactionRequest() { };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<SavePortfolioTransactionRequest, IValidationContext<int>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsTrue(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));
        }
    }
}
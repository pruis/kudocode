using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Inbound;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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
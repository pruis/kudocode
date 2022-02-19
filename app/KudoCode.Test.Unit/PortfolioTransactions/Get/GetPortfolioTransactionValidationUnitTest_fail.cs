using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.PortfolioTransactions.Get
{
	[TestClass]
	public class GetPortfolioTransactionValidationUnitTest : UnitTestBase
	{
		private GetPortfolioTransactionRequest _request;
		private IValidationContext<GetPortfolioTransactionResponse> _getResponse ;

		public GetPortfolioTransactionValidationUnitTest()
		{
		}

		[TestMethod]
		public void GetPortfolioTransactionRequestValidation()
		{
			base.Run(
				"GetPortfolioTransactionRequest Validation",
				"",
				"",
				"");
		}

		protected override void Seed()
		{

		}

		protected override void Given()
		{
			_request = new GetPortfolioTransactionRequest() { };
		}

		protected override void When()
		{
			_getResponse  = ApplicationContext
				.Container
				.Resolve<IHandler<GetPortfolioTransactionRequest, IValidationContext<GetPortfolioTransactionResponse>>>()
				.Handle(_request);
		}

		protected override void Then()
		{
			Assert.IsTrue(_getResponse .Messages.Any(a =>
				a.Type == MessageDtoType.Error));
		}
	}
}

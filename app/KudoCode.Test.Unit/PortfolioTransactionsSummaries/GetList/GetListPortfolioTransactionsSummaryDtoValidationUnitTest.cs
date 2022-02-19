using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.PortfolioTransactionsSummaries.GetList
{
	[TestClass]
	public class GetListPortfolioTransactionsSummaryValidationUnitTest : UnitTestBase
	{
		private GetListPortfolioTransactionsSummaryRequest _request;
		private IValidationContext<GetListPortfolioTransactionsSummaryResponse> _getResponse ;

		[TestMethod]
		public void GetListPortfolioTransactionsSummaryDtoValidation()
		{
			base.Run(
				"GetListPortfolioTransactionsSummaryDto Validation",
				"",
				"",
				"");
		}

		protected override void Seed()
		{

		}

		protected override void Given()
		{
			_request = new GetListPortfolioTransactionsSummaryRequest() { };
		}

		protected override void When()
		{
			_getResponse  = ApplicationContext
				.Container
				.Resolve<IHandler<GetListPortfolioTransactionsSummaryRequest, IValidationContext<GetListPortfolioTransactionsSummaryResponse>>>()
				.Handle(_request);
		}

		protected override void Then()
		{
			Assert.IsTrue(_getResponse.Messages.Any(a =>
				a.Type == MessageDtoType.Error));

			Assert.IsTrue(_getResponse.Messages.Any(a =>
				a.Key == "E6"));

			Assert.IsTrue(_getResponse.Messages.Any(a =>
				a.Message.Contains("Portfolio Id")));
		}
	}
}

using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.Contracts;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.PortfolioTransactionsSummaries.Get
{
	[TestClass]
	public class GetPortfolioTransactionsSummaryAuthorizationUnitTest : UnitTestBase
	{
		private GetPortfolioTransactionsSummaryRequest _request;
		private IAuthorizationContext<GetPortfolioTransactionsSummaryResponse> _getResponse ;

		[TestMethod]
		public void GetPortfolioTransactionsSummaryRequestAuthorization()
		{
			base.Run(
				"GetPortfolioTransactionsSummaryRequest Authorization",
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
			_request = new GetPortfolioTransactionsSummaryRequest() { };
		}

		protected override void When()
		{
			_getResponse  = ApplicationContext
				.Container
				.Resolve<IHandler<GetPortfolioTransactionsSummaryRequest, IAuthorizationContext<GetPortfolioTransactionsSummaryResponse>>>()
				.Handle(_request);
		}

		protected override void Then()
		{
			Assert.IsFalse(_getResponse .Messages.Any(a =>
				a.Type == MessageDtoType.Error));
		}
	}
}

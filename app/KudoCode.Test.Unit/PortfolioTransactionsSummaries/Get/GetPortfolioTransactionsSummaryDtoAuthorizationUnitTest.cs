using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
			ApplicationContext.Container.Resolve<IAuthenticationContext<GetPortfolioTransactionsSummaryResponse>>().IsValidTokenProvided = true;

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

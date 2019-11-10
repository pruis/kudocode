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
	public class SavePortfolioTransactionAuthorizationUnitTest : UnitTestBase
	{
		private SavePortfolioTransactionRequest _request;
		private IAuthorizationContext<int> _getResponse ;

		[TestMethod]
		public void SavePortfolioTransactionRequestAuthorization()
		{
			base.Run(
				"SavePortfolioTransactionRequest Authorization",
				"",
				"",
				"");
		}

		protected override void Seed()
		{
			ApplicationContext.Container.Resolve<IAuthenticationContext<int>>().IsValidTokenProvided = true;
		}

		protected override void Given()
		{
			_request = new SavePortfolioTransactionRequest() { };
		}

		protected override void When()
		{
			_getResponse  = ApplicationContext
				.Container
				.Resolve<IHandler<SavePortfolioTransactionRequest, IAuthorizationContext<int>>>()
				.Handle(_request);
		}

		protected override void Then()
		{
			Assert.IsFalse(_getResponse .Messages.Any(a =>
				a.Type == MessageDtoType.Error));
		}
	}
}

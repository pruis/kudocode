using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Inbound;
using KudoCode.Contracts;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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
			ApplicationContext.Container.Resolve<IApplicationUserContext>().Token.IsValidTokenProvided = true;
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

using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using static KudoCode.Contracts.MessageDtoType;

namespace KudoCode.Test.Unit.Portfolios.SavePortfolio
{
	[TestClass]
	public class SavePortfolioAuthorizationUnitTest : UnitTestBase
	{
		private SavePortfolioRequest _request;
		private IAuthorizationContext<int> _getResponse ;

		public SavePortfolioAuthorizationUnitTest()
		{
		}

		[TestMethod]
		public void SavePortfolioDtoAuthorization()
		{
			base.Run(
				"SavePortfolioDto Authorization",
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
			_request = new SavePortfolioRequest() { };
		}

		protected override void When()
		{
			_getResponse  = ApplicationContext
				.Container
				.Resolve<IHandler<SavePortfolioRequest, IAuthorizationContext<int>>>()
				.Handle(_request);
		}

		protected override void Then()
		{
			Assert.IsFalse(_getResponse .Messages.Any(a =>
				a.Type == Error));
		}
	}
}

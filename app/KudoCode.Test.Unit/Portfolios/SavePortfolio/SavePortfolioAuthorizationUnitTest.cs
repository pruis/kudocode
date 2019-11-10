using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.Test.Unit.AutoFacModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KudoCode.LogicLayer.Infrastructure.Dtos.Messages.MessageDtoType;

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
			ApplicationContext.Container.Resolve<IAuthenticationContext<int>>().IsValidTokenProvided = true;

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

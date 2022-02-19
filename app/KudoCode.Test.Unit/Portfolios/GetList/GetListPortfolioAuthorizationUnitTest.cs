using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Contracts;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.Portfolios.GetList
{
	[TestClass]
	public class GetListPortfolioAuthorizationUnitTest : UnitTestBase
	{
		private GetListPortfolioRequest _request;
		private IAuthorizationContext<GetListPortfolioResponse> _getResponse;

		[TestMethod]
		public void GetListPortfolioDtoAuthorization()
		{
			base.Run(
				"GetListPortfolioDto Authorization",
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
			_request = new GetListPortfolioRequest() { };
		}

		protected override void When()
		{
			_getResponse = ApplicationContext
				.Container
				.Resolve<IHandler<GetListPortfolioRequest, IAuthorizationContext<GetListPortfolioResponse>>>()
				.Handle(_request);
		}

		protected override void Then()
		{
			Assert.IsFalse(_getResponse.Messages.Any(a =>
				a.Type == MessageDtoType.Error));
		}
	}
}
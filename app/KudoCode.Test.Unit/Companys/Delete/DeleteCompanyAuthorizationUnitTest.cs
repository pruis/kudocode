using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Companys.Outbound;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Contracts;
using KudoCode.Test.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Core.Test.Unit.Companys.Delete
{
	[TestClass]
	public class DeleteCompanyAuthorizationUnitTest : UnitTestBase
	{
		private DeleteCompanyRequest _request;
		private IAuthorizationContext<DeleteCompanyResponse> _getResponse ;

		public DeleteCompanyAuthorizationUnitTest()
		{
		}

		[TestMethod]
		public void DeleteCompanyRequestAuthorization()
		{
			base.Run(
				"DeleteCompanyRequest Authorization",
				"",
				"",
				"");
		}

		protected override void Seed()
		{
		}

		protected override void Given()
		{
			_request = new DeleteCompanyRequest() { };
		}

		protected override void When()
		{
			_getResponse  = ApplicationContext
				.Container
				.Resolve<IHandler<DeleteCompanyRequest, IAuthorizationContext<DeleteCompanyResponse>>>()
				.Handle(_request);
		}

		protected override void Then()
		{
			Assert.IsFalse(_getResponse .Messages.Any(a =>
				a.Type == MessageDtoType.Error));
		}
	}
}

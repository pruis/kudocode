using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Comanys.Outbound;
using KudoCode.Contracts;
using KudoCode.Test.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Core.Test.Unit.Comanys.Get
{
	[TestClass]
	public class GetComanyValidationUnitTest : UnitTestBase
	{
		private GetCompanyRequest _request;
		private IValidationContext<GetCompanyResponse> _getResponse ;

		public GetComanyValidationUnitTest()
		{
		}

		[TestMethod]
		public void GetCompanyRequestValidation()
		{
			base.Run(
				"GetComanyRequest Validation",
				"",
				"",
				"");
		}

		protected override void Seed()
		{
		}

		protected override void Given()
		{
			_request = new GetCompanyRequest() { };
		}

		protected override void When()
		{
			_getResponse  = ApplicationContext
				.Container
				.Resolve<IHandler<GetCompanyRequest, IValidationContext<GetCompanyResponse>>>()
				.Handle(_request);
		}

		protected override void Then()
		{
			Assert.IsFalse(_getResponse .Messages.Any(a =>
				a.Type == MessageDtoType.Error));
		}
	}
}

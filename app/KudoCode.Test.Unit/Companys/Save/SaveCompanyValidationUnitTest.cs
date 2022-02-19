using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Companys.Outbound;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Contracts;
using KudoCode.Test.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Core.Test.Unit.Companys.Save
{
	[TestClass]
	public class SaveCompanyValidationUnitTest : UnitTestBase
	{
		private SaveCompanyRequest _request;
		private IValidationContext<SaveCompanyResponse> _getResponse;

		public SaveCompanyValidationUnitTest()
		{
		}

		[TestMethod]
		public void SaveCompanyRequestValidation()
		{
			base.Run(
				"SaveCompanyRequest Validation",
				"",
				"",
				"");
		}

		protected override void Seed()
		{
		}

		protected override void Given()
		{
			_request = new SaveCompanyRequest() { };
		}

		protected override void When()
		{
			_getResponse = ApplicationContext
				.Container
				.Resolve<IHandler<SaveCompanyRequest, IValidationContext<SaveCompanyResponse>>>()
				.Handle(_request);
		}

		protected override void Then()
		{
			Assert.IsFalse(_getResponse.Messages.Any(a =>
			   a.Type == MessageDtoType.Error));
		}
	}
}

using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Comanys.Outbound;
using KudoCode.Contracts;
using KudoCode.Test.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Core.Test.Unit.Comanys.List
{
	[TestClass]
	public class ListComanyValidationUnitTest : UnitTestBase
	{
		private ListCompanyRequest _request;
		private IValidationContext<ListCompanyResponse> _getResponse ;

		public ListComanyValidationUnitTest()
		{
		}

		[TestMethod]
		public void ListComanyRequestValidation()
		{
			base.Run(
				"ListComanyRequest Validation",
				"",
				"",
				"");
		}

		protected override void Seed()
		{
		}

		protected override void Given()
		{
			_request = new ListCompanyRequest() { };
		}

		protected override void When()
		{
			_getResponse  = ApplicationContext
				.Container
				.Resolve<IHandler<ListCompanyRequest, IValidationContext<ListCompanyResponse>>>()
				.Handle(_request);
		}

		protected override void Then()
		{
			Assert.IsFalse(_getResponse .Messages.Any(a =>
				a.Type == MessageDtoType.Error));
		}
	}
}

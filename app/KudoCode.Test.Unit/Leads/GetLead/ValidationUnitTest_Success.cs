using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.Leads.GetLead
{
	[TestClass]
	public class ValidationUnitTest_Success : UnitTestBase
	{
		private int _leadId;
		private GetLeadRequest _getLeadRequest;
		private IValidationContext<GetLeadResponse> _getResponse ;

		public ValidationUnitTest_Success()
		{
		}

		[TestMethod]
		public void Success()
		{
			base.Run(
				"GetLeadDto Validation - SUCCESS",
				"Given a valid GetLeadDto",
				"When I vaildate the dto",
				"Then I receive no error messages");
		}

		protected override void Seed()
		{
			_leadId = 1;
		}

		protected override void Given()
		{
			_getLeadRequest = new GetLeadRequest() { Id = _leadId };
		}

		protected override void When()
		{
			_getResponse  = ApplicationContext
				.Container
				.Resolve<IHandler<GetLeadRequest, IValidationContext<GetLeadResponse>>>()
				.Handle(_getLeadRequest);
		}

		protected override void Then()
		{
			Assert.IsTrue(!_getResponse.Messages.Any());
		}

	}
}

using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.Test.Unit.AutoFacModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KudoCode.LogicLayer.Infrastructure.Dtos.Messages.MessageDtoType;
namespace KudoCode.Test.Unit.Leads.GetLead
{
	[TestClass]
	public class AuthorizationUnitTest_Fail : UnitTestBase
	{
		private int _leadId;
		private GetLeadRequest _getLeadRequest;
		private IAuthorizationContext<GetLeadResponse> _getResponse ;

		public AuthorizationUnitTest_Fail()
		{
		}

		[TestMethod]
		public void GetLeadDtoAuthorization()
		{
			base.RegisterModule(
				new Module_ApplicationUserContext_With_No_Authorization());

			base.Run(
				"GetLeadDto Authorization - FAIL",
				"Given a user with no Authorization",
				"When Authorizing the request",
				"Then an error message was received");
		}

		protected override void Seed()
		{
			_leadId = 0;
		}

		protected override void Given()
		{
			_getLeadRequest = new GetLeadRequest() { Id = _leadId };
		}

		protected override void When()
		{
			_getResponse  = ApplicationContext
				.Container
				.Resolve<IHandler<GetLeadRequest, IAuthorizationContext<GetLeadResponse>>>()
				.Handle(_getLeadRequest);
		}

		protected override void Then()
		{
			Assert.IsTrue(_getResponse .Messages.Any(a =>
				a.Type == Error &&
				a.Key == "E3"));
		}
	}
}

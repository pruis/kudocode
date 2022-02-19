using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos.Interfaces;
using KudoCode.Test.Unit.AutoFacModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.EntityAudit_.Create
{
	[TestClass]
	public class CreateEntityAuditDtoAuthorizationUnitTest_FAIL : UnitTestBase
	{
		private CreateEntityAuditDto _createEntityAuditDto;
		private IAuthorizationContext<int> _handlerResponse;

		[TestMethod]
		public void Create()
		{
			RegisterModule(new Module_ApplicationUserContext_With_No_Authorization());
			base.Run(
				"CreateEntityAuditDto Authorization - FAIL",
				"Given ",
				"When ",
				"Then ");
		}

		protected override void Seed()
		{
		}

		protected override void Given()
		{
			_createEntityAuditDto = new CreateEntityAuditDto() { };
		}

		protected override void When()
		{
			_handlerResponse = ApplicationContext
				.Container
				.Resolve<IHandler<ICreateEntityAuditDto, IAuthorizationContext<int>>>()
				.Handle(_createEntityAuditDto);
		}

		protected override void Then()
		{
			Assert.IsTrue(_handlerResponse.Messages.Any(a => a.Key.Equals("E3")));
		}
	}
}
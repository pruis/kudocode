using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.AutofacModules;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos;
using KudoCode.LogicLayer.Plugin.EntityAudit_.UnitTests.AutofacModules;
using KudoCode.LogicLayer.Plugin.EntityAudit_.UnitTests.Base;
using KudoCode.LogicLayer.Plugin.EntityAudit_.UnitTests.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.UnitTests
{
	[TestClass]
	public class EntityAuditUnitTest : UnitTestBase
	{
		private IHandler<RequestDto, IWorkerContext<ResponseDto>> _handler;

		[TestMethod]
		public void EntityAudit()
		{
			this.RegisterModule(new AutoMapperModule());
			this.RegisterModule(new EntityAuditAutoFac());
			this.RegisterModule(new EntityAuditTestAutofac());
			Run("Entity Audit test ", "", "", "");
		}

		protected override void Seed()
		{
		}

		protected override void Given()
		{
			_handler = Scope.Resolve<IHandler<RequestDto, IWorkerContext<ResponseDto>>>();
		}

		protected override void When()
		{
			_handler.Handle(new RequestDto());
		}

		protected override void Then()
		{
			var context = Scope.Resolve<IWorkerContext<ResponseDto>>();

			var entityAudit = ((EventRequestDto<CreateEntityAuditEventMessage>)context.Events[0]).MetaData;
			Assert.IsTrue(entityAudit.PropertyInformation.Count == 3);

			Assert.IsTrue(entityAudit.PropertyInformation[0].Value.Equals("1"));
			//Assert.IsTrue(entityAudit.EntityAudit[0].Name == "");

			Assert.IsTrue(entityAudit.PropertyInformation[1].Value.Equals("Test"));
			//Assert.IsTrue(entityAudit.EntityAudit[1].Name == "");

			Assert.IsTrue(entityAudit.PropertyInformation[2].Value.Equals("2"));

			//Assert.IsTrue(entityAudit.EntityAudit[2].Name == "");
		}
	}
}
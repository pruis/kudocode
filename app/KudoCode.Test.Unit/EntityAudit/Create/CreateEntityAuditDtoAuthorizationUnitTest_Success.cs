using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.EntityAudit_.Create
{
    [TestClass]
    public class CreateEntityAuditDtoAuthorizationUnitTest_Success : UnitTestBase
    {
        private CreateEntityAuditDto _createEntityAuditDto;
        private IAuthorizationContext<int> _handlerResponse;

        public CreateEntityAuditDtoAuthorizationUnitTest_Success()
        {
        }

        [TestMethod]
        public void Create()
        {
            base.Run(
                "CreateEntityAuditDto Authorization - SUCCESS",
                "Given ",
                "When ",
                "Then ");
        }

        protected override void Seed()
        {
            ApplicationContext.Container.Resolve<IApplicationUserContext>().Token.IsValidTokenProvided = true;
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
            Assert.IsFalse(_handlerResponse.Messages.Any());
        }
    }
}
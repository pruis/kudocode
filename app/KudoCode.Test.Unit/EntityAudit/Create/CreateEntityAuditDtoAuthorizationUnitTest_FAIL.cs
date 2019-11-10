using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.LogicLayer.Plugin.EntityAudit.Dtos;
using KudoCode.LogicLayer.Plugin.EntityAudit.Dtos.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.EntityAudit.Create
{
    [TestClass]
    public class CreateEntityAuditDtoAuthorizationUnitTest_FAIL : UnitTestBase
    {
        private CreateEntityAuditDto _createEntityAuditDto;
        private IAuthorizationContext<int> _handlerResponse;

        [TestMethod]
        public void Create()
        {
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
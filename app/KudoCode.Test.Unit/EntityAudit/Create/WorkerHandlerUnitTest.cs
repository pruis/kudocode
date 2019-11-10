using System.Collections.Generic;
using Autofac;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.LogicLayer.Plugin.EntityAudit.Dtos;
using KudoCode.LogicLayer.Plugin.EntityAudit.Dtos.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.EntityAudit.Create
{
    [TestClass]
 
    public class CreateEntityAuditDtoWorkerHandlerUnitTest_SUCCESS : UnitTestBase
    {
        private CreateEntityAuditDto _createEntityAuditDto;
        private IWorkerContext<int> _handlerResonse;
        private LogicLayer.Plugin.EntityAudit.Domain.Logic.EntityAudits.Entities.EntityAudit _entityAudit;

        [TestMethod]
        public void CreateEntityAuditDto()
        {
            base.Run(
                "CreateEntityAuditDto WorkerHAndler",
                "Given ",
                "When ",
                "Then ");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            _createEntityAuditDto = new CreateEntityAuditDto()
            {
                EntityId = 1,
                Entity = "Lead",
                ApplicationUserId = 1,
                PropertyInformation = new List<PropertyInformationDto>()
                {
                    new PropertyInformationDto {Name = "Name 1", Value = "Value 1"},
                    new PropertyInformationDto {Name = "Name 2", Value = "Value 2"},
                }
            };
        }

        protected override void When()
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope(ScopeKey))
            {
                _handlerResonse = scope
                    .Resolve<IHandler<ICreateEntityAuditDto, IWorkerContext<int>>>()
                    .Handle(_createEntityAuditDto);

                _entityAudit = scope.Resolve<IReadOnlyRepository>()
                    .GetOne<LogicLayer.Plugin.EntityAudit.Domain.Logic.EntityAudits.Entities.EntityAudit>(
                        a => a.Id == _handlerResonse.Result, "PropertyInformation");
            }
        }

        protected override void Then()
        {
            Assert.IsTrue(_entityAudit != null);
            Assert.IsTrue(_entityAudit.Id == _handlerResonse.Result);
        }
    }
}
using System.Collections.Generic;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using KudoCode.LogicLayer.Plugin.EntityAudit.UnitTests.Objects;

namespace KudoCode.LogicLayer.Plugin.EntityAudit.UnitTests.Handlers
{
    public class TestCommandHandler : CommandHandler<RequestDto, Entity, ResponseDto>
    {
        public TestCommandHandler(IMapper mapper, IRepository repository, IComponentContext scope,
            IWorkerContext<ResponseDto> context) : base(mapper, repository, scope, context)
        {
        }

        protected override void GetEntity()
        {
        }

        protected override void Execute()
        {
            Entity = new Entity()
            {
                Id = 1,
                Name = "Test",
                AssociatedEntities = new List<AssociatedEntity>()
                {
                    new AssociatedEntity()
                        {Id = 2, Name = "AssociatedEntity"}
                }
            };
        }
    }
}
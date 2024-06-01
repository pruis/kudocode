using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Plugin.EntityAudit_.UnitTests.Objects;
using System.Collections.Generic;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.UnitTests.Handlers
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
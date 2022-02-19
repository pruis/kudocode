using Autofac;
using KudoCode.Abstract.Persistence.EntityFramework;
using KudoCode.LogicLayer.Domain.Repository;
using KudoCode.Contracts.Api;
using Microsoft.EntityFrameworkCore;

namespace KudoCode.Web.Api
{
	public class AutoFacEntityFrameworkInMemory : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryDataContext>().AsSelf().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<EntityFrameworkRepository<InMemoryDataContext>>().As<IRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<EntityFrameworkReadOnlyRepository<InMemoryDataContext>>().As<IReadOnlyRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
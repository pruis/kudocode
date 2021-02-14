using Autofac;
using KudoCode.LogicLayer.Domain.Repository;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace KudoCode.LogicLayer.Domain.ContainerModules
{
    public class AutoFacEntityFrameworkMsSql : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataContext>().AsSelf().As<DbContext>()
                .InstancePerLifetimeScope();
            builder.RegisterType<EntityFrameworkRepository<DataContext>>().As<IRepository>()
                .InstancePerLifetimeScope()
                ;
            builder.RegisterType<EntityFrameworkReadOnlyRepository<DataContext>>().As<IReadOnlyRepository>()
                .InstancePerLifetimeScope()
                ;
        }
    }
}
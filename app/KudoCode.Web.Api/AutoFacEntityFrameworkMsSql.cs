using Autofac;
using KudoCode.Abstract.Persistence.EntityFramework;
using KudoCode.LogicLayer.Domain.Repository;
using KudoCode.Contracts.Api;
using Microsoft.EntityFrameworkCore;

namespace KudoCode.Web.Api
{
	public class AutoFacEntityFrameworkMsSql : Module
    {
        protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<DataContext>().AsSelf().As<DbContext>()
				.InstancePerLifetimeScope();
			NewMethod(builder).As<IRepository>()
							.InstancePerLifetimeScope()
							;
			builder.RegisterType<EntityFrameworkReadOnlyRepository<DataContext>>().As<IReadOnlyRepository>()
				.InstancePerLifetimeScope()
				;
		}

		private static Autofac.Builder.IRegistrationBuilder<EntityFrameworkRepository<DataContext>, Autofac.Builder.ConcreteReflectionActivatorData, Autofac.Builder.SingleRegistrationStyle> NewMethod(ContainerBuilder builder)
		{
			return builder.RegisterType<EntityFrameworkRepository<DataContext>>();
		}
	}
}
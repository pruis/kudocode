using System;
using Autofac;
using KudoCode.LogicLayer.Infrastructure.Domain.Logic.Lookup.Context;
using KudoCode.LogicLayer.Infrastructure.Domain.Logic.Lookup.Handlers.GetLookups;

namespace KudoCode.LogicLayer.Infrastructure.Domain
{
    public class AutoFacInfrastructureDomain : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(AuthenticationHandler<,>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterInstance(new ListILookup()).AsSelf().SingleInstance();
            builder.RegisterType<GetLookupRequestContext>().As<IGetLookupRequestContext>().InstancePerLifetimeScope();
        }
    }
}
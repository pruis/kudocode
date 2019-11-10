using System;
using System.Collections.Generic;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.Portfolios.Entities;
using KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.AutoMapper;
using KudoCode.LogicLayer.Plugin.EntityAudit.Domain.Logic.EntityAudits.AutoMapper;

namespace KudoCode.LogicLayer.Domain.ContainerModules
{
    public class AutofacAutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //https://github.com/RichardSlater/AutoMapperWithAutofac/blob/master/README.md
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(ITypeConverter<,>))
                .AsImplementedInterfaces();


            builder.RegisterAssemblyTypes(typeof(EntityAuditAutoMapper).Assembly)
                .AssignableTo<Profile>().As<Profile>();

            builder.RegisterAssemblyTypes(typeof(ApplicationUserAutoMapper).Assembly)
                .AssignableTo<Profile>().As<Profile>();

            builder.RegisterAssemblyTypes(typeof(Portfolio).Assembly)
                .AssignableTo<Profile>().As<Profile>();

            builder.Register(context =>
                {
                    var profiles = context.Resolve<IEnumerable<Profile>>();

                    var config = new MapperConfiguration(x =>
                    {
                        foreach (var profile in profiles)
                            x.AddProfile(profile);
                    });
                    return config;
                }).SingleInstance() // We only need one instance
                //.InstancePerLifetimeScope()
                .AsSelf(); // Bind it to its own type

            // HACK: IComponentContext needs to be resolved again as 'tempContext' is only temporary. See http://stackoverflow.com/a/5386634/718053 
            builder.Register(tempContext =>
            {
                var ctx = tempContext.Resolve<IComponentContext>();
                var config = ctx.Resolve<MapperConfiguration>();

                // Create our mapper using our configuration above
                return config.CreateMapper();
            }).As<IMapper>(); // Bind it to the IMapper interface

            base.Load(builder);
        }
    }
}
using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.Abstract.Persistence.EntityFramework;
using KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.Get;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace KudoCode.Test.Unit.AutoFacModule
{
	public class Module_UnitTest : Module
    {
        private bool _isTest;

        public Module_UnitTest(bool isTest = false)
        {
            _isTest = isTest;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //            Constants.EventSources.Sources.ForEach(source =>
            //                builder.RegisterType<RabbitMqManager>()
            //                    .As<IEventManager>()
            //                    .Named(source, typeof(IEventManager))
            //                    .WithParameter(new TypedParameter(typeof(string), source))
            //                    .SingleInstance()
            //            );

            builder.RegisterType<MemoryCache>().As<IMemoryCache>().SingleInstance();
            builder.RegisterGeneric(typeof(OptionsManager<>)).As(typeof(IOptions<>)).SingleInstance();
            builder.RegisterGeneric(typeof(OptionsManager<>)).As(typeof(IOptionsSnapshot<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(OptionsMonitor<>)).As(typeof(IOptionsMonitor<>)).SingleInstance();
            builder.RegisterGeneric(typeof(OptionsFactory<>)).As(typeof(IOptionsFactory<>));
            builder.RegisterGeneric(typeof(OptionsCache<>)).As(typeof(IOptionsMonitorCache<>)).SingleInstance();

            builder.RegisterType<InMemoryDataContextUnitTest>().AsSelf().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<EntityFrameworkRepository<InMemoryDataContextUnitTest>>().As<IRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<EntityFrameworkReadOnlyRepository<InMemoryDataContextUnitTest>>().As<IReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GetLeadWorkerHandler>();

            builder.RegisterType<ExecutionPipelineHandlers>()
                .AsSelf().As<ExecutionPipelineHandlers>().InstancePerLifetimeScope()
                .WithParameter("types", new List<Type>()
                {
                    typeof(GetLeadWorkerHandler),
                    typeof(GetLeadWorkerHandler),
                }).InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("UnitTest"))
                .AsImplementedInterfaces();


            //builder.RegisterGeneric(typeof(AuthenticationDummyFilter<,>));

            //builder.RegisterType<ExecutionPipeline>()
            //    .As<ISecondaryExecutionPipeline>()
            //    .WithParameter("types", new List<Type>()
            //    {
            //        typeof(AuthenticationDummyFilter<,>),
            //        typeof(AuthorizationFilter<,>),
            //        typeof(FluentValidationFilter<,>),
            //        typeof(WorkerFilter<,>),
            //    }).InstancePerLifetimeScope();

        }
    }
}
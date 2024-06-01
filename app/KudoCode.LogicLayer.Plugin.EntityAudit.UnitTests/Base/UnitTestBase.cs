using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.Infrastructure.AutoFac.Api;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using TestStack.BDDfy;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.UnitTests.Base
{
	public abstract class UnitTestBase : IUnitTestBase, IDisposable
    {
        private readonly List<Module> _modules = new List<Module>();
        protected abstract void Seed();
        protected readonly string ScopeKey = "ExecutionPipeline";

        public void Run(string scenarioTitle, string given, string when, string then)
        {
            try
            {
                Init();

                Seed();

                this.Given(_ => Given(), given)
                    .When(_ => When(), when)
                    .Then(_ => Then(), then)
                    .BDDfy(scenarioTitle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void Init()
        {
            //Read config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            
            var builder = new ContainerBuilder();
            builder.RegisterInstance(config).As<IConfiguration>();
            builder.RegisterType<MemoryCache>().As<IMemoryCache>().SingleInstance();
            builder.RegisterGeneric(typeof(OptionsManager<>)).As(typeof(IOptions<>)).SingleInstance();
            builder.RegisterGeneric(typeof(OptionsManager<>)).As(typeof(IOptionsSnapshot<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(OptionsMonitor<>)).As(typeof(IOptionsMonitor<>)).SingleInstance();
            builder.RegisterGeneric(typeof(OptionsFactory<>)).As(typeof(IOptionsFactory<>));
            builder.RegisterGeneric(typeof(OptionsCache<>)).As(typeof(IOptionsMonitorCache<>)).SingleInstance();

            builder.RegisterModule(new AbstractContractsAutoFac());
            _modules.ForEach(a => builder.RegisterModule(a));
            ApplicationContext.Container = builder.Build();
            if (Scope == null)
                Scope = ApplicationContext.Container.BeginLifetimeScope(ScopeKey);
        }

        protected static ILifetimeScope Scope { get; set; }

        internal void RegisterModule(Module module)
        {
            _modules.Add(module);
        }

        protected abstract void Given();
        protected abstract void When();
        protected abstract void Then();

        public void Dispose()
        {
            if (ApplicationContext.Container != null)
                ApplicationContext.Container.Dispose();
        }
    }
}
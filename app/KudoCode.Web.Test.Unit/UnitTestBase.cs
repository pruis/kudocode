﻿using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.Infrastructure.AutoFac.Api;
using KudoCode.Infrastructure.AutoFac.Web;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using TestStack.BDDfy;

namespace KudoCode.Web.Test.Unit
{
	public abstract class UnitTestBase : IUnitTestBase, IDisposable
    {
        private readonly List<Module> _modules = new List<Module>();
        protected abstract void Seed();
        protected readonly string ScopeKey = "ExecutionPipeline";

        public void Run(string scenarioTitle, string given, string when, string then)
        {
            Init();
            //SeedDataBase.DropAndCreate();

            Seed();

            this.Given(_ => Given(), given)
                .When(_ => When(), when)
                .Then(_ => Then(), then)
                .BDDfy(scenarioTitle);
        }

        private void Init()
        {
            var configBuilder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                ;
            var configuration = configBuilder.Build();

            var builder = new ContainerBuilder();

            builder.RegisterInstance<IConfiguration>(configuration);


            builder.RegisterModule(new KudoCodeLocalStorageModule());
            builder.RegisterModule(new AbstractContractsAutoFac());
//            builder.RegisterModule(new AutoFacInfrastructureDomain());
//            builder.RegisterModule(new AutofacAutoMapperModule());
//            builder.RegisterModule(new RedisAutoFac_Testing());
//            builder.RegisterModule(new AutoFacDomain());
//            builder.RegisterModule(new Module_UnitTest());
//            builder.RegisterModule(new AutofacEntityAudit());
//            builder.RegisterModule(new Module_ApplicationUserContext_With_GroupAll_Admin());
            _modules.ForEach(a => builder.RegisterModule(a));
            ApplicationContext.Container = builder.Build();

            DateFormat = ApplicationContext.Container.Resolve<IConfiguration>()["DateFormat"];
//            ApplicationContext.Container.Resolve<IMapper>();
        }

        protected string DateFormat { get; set; }

        internal void RegisterModule(Module module)
        {
            _modules.Add(module);
        }

        protected abstract void Given();
        protected abstract void When();
        protected abstract void Then();

        public void Dispose()
        {
//            SeedDataBase.Drop();
//            if (ApplicationContext.Container != null)
//                ApplicationContext.Container.Dispose();
        }
    }
}
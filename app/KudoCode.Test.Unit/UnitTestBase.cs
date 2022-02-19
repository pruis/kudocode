﻿using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Infrastructure.AutoFac.Api;
using KudoCode.Infrastructure.AutoFac.Application;
using KudoCode.LogicLayer.Domain;
using KudoCode.LogicLayer.Domain.ContainerModules;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.AutofacModules;
using KudoCode.Test.Unit.AutoFacModule;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using TestStack.BDDfy;

namespace KudoCode.Test.Unit
{
    public abstract class UnitTestBase : IUnitTestBase, IDisposable
    {
        private readonly List<Module> _modules = new List<Module>();
        protected abstract void Seed();
        protected readonly string ScopeKey = "ExecutionPipeline";
        public InMemoryDataContextUnitTest DataContext { get; private set; }

        public void Run(string scenarioTitle, string given, string when, string then)
        {
            Init();
            SeedDataBase.DropAndCreate();

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

            builder.RegisterModule(new AbstractContractsAutoFac());
            builder.RegisterModule(new AbstractApplicationAutoFac());
            builder.RegisterModule(new AutofacAutoMapperModule());
            //builder.RegisterModule(new RedisAutoFac_Testing());
            builder.RegisterModule(new AutoFacDomain());
            builder.RegisterModule(new Module_UnitTest());
            builder.RegisterModule(new AutofacEntityAudit());
            builder.RegisterModule(new Module_ApplicationUserContext_With_GroupAll_Admin());
            _modules.ForEach(a => builder.RegisterModule(a));
            try
            {
                ApplicationContext.Container = builder.Build();
            }
            catch (Exception ex)
            {

                throw;
            }

            DateFormat = ApplicationContext.Container.Resolve<IConfiguration>()["DateFormat"];
            ApplicationContext.Container.Resolve<IMapper>();
            DataContext = ApplicationContext.Container.Resolve<InMemoryDataContextUnitTest>();

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
            SeedDataBase.Drop();
            if (ApplicationContext.Container != null)
                ApplicationContext.Container.Dispose();
        }
    }
}
using System;
using System.Collections.Generic;
using Autofac;
using KudoCode.LogicLayer.Domain.ContainerModules;
using KudoCode.LogicLayer.Domain.Logic;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreateImportXls;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreatePortfolio;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreatePortfolioTransactionsConsolidation;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreatePortfolioTransactionsSummary;
using KudoCode.LogicLayer.Infrastructure.Domain;
using KudoCode.LogicLayer.Infrastructure.Execution.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.PipeLines;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Messages;
using KudoCode.LogicLayer.Plugin.Redis.Domain.Logic.Redis.Plugin;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;
using Microsoft.AspNetCore.Authentication;

namespace KudoCode.LogicLayer.Domain
{
    public class AutoFacDomain : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DelegateContext>().AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<MessageProxyCollection>().As<IMessageCollection>().SingleInstance();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("Handler"))
                .AsImplementedInterfaces().AsSelf().PropertiesAutowired();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("AuditDefinition"))
                .AsImplementedInterfaces().AsSelf().PropertiesAutowired();

            builder.RegisterType<ExecutionPipelineHandlers>()
                .Keyed<IExecutionPipelineHandlers>("ImportProfile")
                .InstancePerDependency()
                .WithParameter("types", new List<Type>()
                {
                    typeof(CreateImportXlsDtoWorkerHandler),
                    typeof(CreatePortfolioStgWorkerHandler),
                    typeof(CreatePortfolioTransactionsSummaryStgWorkerHandler),
                    typeof(CreatePortfolioTransactionsConsolidationStgWorkerHandler),
                })
                .InstancePerLifetimeScope();
        }
    }
}
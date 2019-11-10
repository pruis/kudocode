using System;
using System.Collections.Generic;
using Autofac;
using KudoCode.LogicLayer.Domain;
using KudoCode.LogicLayer.Domain.ContainerModules;
using KudoCode.LogicLayer.Domain.Logic;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreateImportXls;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreatePortfolio;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreatePortfolioTransactionsConsolidation;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreatePortfolioTransactionsSummary;
using KudoCode.LogicLayer.Dtos;
using KudoCode.LogicLayer.Infrastructure.Execution.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.PipeLines;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Messages;
using KudoCode.LogicLayer.Plugin.Redis.Domain.Logic.Redis.Plugin;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;
using KudoCode.Messaging.Infrastructure.Interfaces;
using Core.Services.Workflow.RabbitMQ.Infrastructure;

namespace KudoCode.Web.Api
{
    public class AutoFacWebApi : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Constants.EventQueues.Queue.ForEach(source =>
                builder.RegisterType<RabbitMqManager>()
                    .As<IEventManager>()
                    .Named(source, typeof(IEventManager))
                    .WithParameter(new TypedParameter(typeof(string), source))
                    .SingleInstance()
            );
        }
    }
}
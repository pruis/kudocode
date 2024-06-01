using Autofac;
using KudoCode.Contracts;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreateImportXls;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreatePortfolio;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreatePortfolioTransactionsConsolidation;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreatePortfolioTransactionsSummary;
using KudoCode.LogicLayer.Dtos;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.LogicLayer.Domain
{
	public class AutoFacDomain : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<DelegateContext>().AsImplementedInterfaces().InstancePerLifetimeScope();

			builder.RegisterType<MessageProxyCollection>().As<IMessageCollection>().SingleInstance();

			//builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
			//	.Where(t => t.Name.EndsWith("Handler")&& t.FullName.Contains("KudoCode"))
			//	.AsImplementedInterfaces().AsSelf();

			builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
				.Where(t => t.Name.EndsWith("AuditDefinition"))
				.AsImplementedInterfaces().AsSelf();

			builder.RegisterType<ExecutionPipelineHandlers>()
				.Keyed<IExecutionPipelineHandlers>("ImportProfile")
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
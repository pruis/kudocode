using Autofac;
using KudoCode.Contracts;
using KudoCode.Contracts.Api;
using KudoCode.Infrastructure.AutoFac.Api;
using KudoCode.Infrastructure.CodeGenerator.Logic.CodeGen.Handlers.Create;
using KudoCode.Infrastructure.CodeGenerator.Repository;
using KudoCode.Infrastructure.CodeGenerator;
using System;
using System.Collections.Generic;

namespace CodeGenerator.Service
{
	public static class ContainerInstaller
	{
		public static IContainer BuildContainer()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule(new AbstractContractsAutoFac());
			builder.RegisterModule(new AutoMapperModule());

			builder.RegisterType<GenerateHandler>().As<IGenerate>().AsSelf();
			builder.RegisterType<UpdateHandler>().As<IGenerate>().AsSelf();

			builder.RegisterType<MessageProxyCollection>().As<IMessageCollection>().SingleInstance();
			builder.RegisterType<ReadOnlyRepository>().As<IReadOnlyRepository>().SingleInstance();
			builder.RegisterType<Repository>().As<IRepository>().SingleInstance();
			builder.RegisterType<CreateFileDtoWorkerHandler>();
			builder.RegisterType<OutputFileDtoWorkerHandler>();
			builder.RegisterType<UpdateFileDtoWorkerHandler>();
			builder.RegisterType<UpdateOutputFileDtoWorkerHandler>();

			//builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
			//	.Where(t => t.Name.EndsWith("Handler") && t.FullName.Contains("KudoCode"))
			//	.AsImplementedInterfaces().AsSelf()
			//	;

			builder.RegisterType<ExecutionPipelineHandlers>()
				.As<IExecutionPipeline>()
				.AsSelf()
				.WithParameter("types", new List<Type>()
				{
					typeof(CreateFileDtoWorkerHandler),
					typeof(OutputFileDtoWorkerHandler),
					typeof(UpdateFileDtoWorkerHandler),
					typeof(UpdateOutputFileDtoWorkerHandler),
				}).InstancePerLifetimeScope();

			builder.RegisterModule(new CodeGenSettingsModule());
			builder.RegisterType<LogFormatterDummy>().As<ILogFormatter>().InstancePerLifetimeScope();

			var container = builder.Build();
			return container;
		}
	}

	public class LogFormatterDummy : ILogFormatter
	{
		public void Debug(string handlerName, string requestDtoType, string message)
		{
		}
		public void Fatal(string handlerName, string requestDtoType, string message)
		{
		}
	}
}
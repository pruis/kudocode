using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using log4net;
using System;
using System.Collections.Generic;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;
using KudoCode.LogicLayer.Plugin.Redis.Domain.Logic.Redis.Plugin;
using KudoCode.Abstract.Application;

namespace KudoCode.Infrastructure.AutoFac.Api
{
	public class AbstractContractsAutoFac : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ListTableConfigStore>().As<IListTableConfigStore>().SingleInstance();
			builder.RegisterType<ConvertToObjectDictionary>().As<IConvertToObjectDictionary>().SingleInstance();

			builder.RegisterType<ConvertToObject>().As<IConvertToObject>();

			builder.RegisterGeneric(typeof(EventRequestDto<>))
				.As(typeof(IEventRequestDto<>)).InstancePerDependency();

			builder.RegisterGeneric(typeof(FluentValidationHandler<,>))
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
			builder.RegisterGeneric(typeof(IsLoggedOnAuthorizationHandler<,>))
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			builder.RegisterGeneric(typeof(AuthenticationSecondaryFilter<,>));
			builder.RegisterGeneric(typeof(AuthenticationFilter<,>));
			builder.RegisterGeneric(typeof(AuthorizationFilter<,>));
			builder.RegisterGeneric(typeof(FluentValidationFilter<,>));
			builder.RegisterGeneric(typeof(WorkerFilter<,>));
			builder.RegisterGeneric(typeof(EventFilter<,>));
			builder.RegisterGeneric(typeof(AggregateFilter<,>));

			builder.RegisterGeneric(typeof(ExecutionPipelineContext<>))
				.As(typeof(IExecutionPipelineContext<>))
				.As(typeof(IWorkerContext<>))
				.As(typeof(IValidationContext<>))
				.As(typeof(IAuthorizationContext<>))
				.As(typeof(IAuthenticationContext<>))
				.InstancePerLifetimeScope();

			builder.RegisterType<ApiControllerRequestManager>();

			builder.RegisterType<ApplicationUserContext>().As<IApplicationUserContext>()
			   .InstancePerLifetimeScope()
				;

			builder.RegisterType<ExecutionPipeline>()
				.As<IExecutionPipeline>()
				.AsSelf()
				.WithParameter("types", new List<Type>()
				{
					typeof(AuthenticationFilter<,>),
					typeof(AuthorizationFilter<,>),
					typeof(FluentValidationFilter<,>),
					typeof(WorkerFilter<,>),
					typeof(EventFilter<,>),
					typeof(AggregateFilter<,>),
				}).InstancePerLifetimeScope();

			builder.RegisterType<ExecutionPipeline>()
				.As<ISecondaryExecutionPipeline>()
				.WithParameter("types", new List<Type>()
				{
					typeof(AuthenticationSecondaryFilter<,>),
					typeof(AuthorizationFilter<,>),
					typeof(FluentValidationFilter<,>),
					typeof(WorkerFilter<,>),
				}).InstancePerLifetimeScope();

			builder.RegisterType<LogFormatter>().As<ILogFormatter>().InstancePerLifetimeScope();
			builder.Register(c => LogManager.GetLogger(typeof(Object))).As<ILog>();
			builder.RegisterGeneric(typeof(CommandHandlerDelegates<,,>)).InstancePerLifetimeScope();
			builder.RegisterGeneric(typeof(QueryHandlerDelegates<,,>)).InstancePerLifetimeScope();
			builder.RegisterGeneric(typeof(WorkerHandlerDelegates<,>)).InstancePerLifetimeScope();

			builder
				.RegisterType<ProxyTokenCache>()
				.As<ITokenCache>().InstancePerLifetimeScope();

			//I think this registers twice in applications using nugets
			builder.RegisterGeneric(typeof(GetApplicationUserContextAuthenticationHandler<,>))
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			builder.RegisterType<ValidateTokenAuthenticationHandler>();

			builder.RegisterType<ExecutionPipelineHandlers>()
				.Keyed<IExecutionPipeline>("ValidateToken")
				.WithParameter("types", new List<Type>()
				{
								typeof(ValidateTokenAuthenticationHandler),
				}).InstancePerLifetimeScope();


			builder
				.RegisterType<DelegateContext>()
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			builder
				.RegisterGeneric(typeof(InMemoryCacheQueryHandlerPlugin<,,>))
				.As(typeof(IQueryHandlerDelegates<,,>))
				.PropertiesAutowired().InstancePerLifetimeScope();

			builder
				.RegisterGeneric(typeof(InmemoryCacheCommandHandlerPlugin<,,>))
				.As(typeof(ICommandHandlerDelegates<,,>))
				.PropertiesAutowired().InstancePerLifetimeScope();

			builder
				.RegisterType<MessageProxyCollection>()
				.As<IMessageCollection>()
				.SingleInstance();

			builder
				.RegisterType(typeof(GetApplicationUserDtoWorkerHandler))
				.As(typeof(IHandler<GetApplicationUserDto, IWorkerContext<ApplicationUserDto>>))
				.PropertiesAutowired().InstancePerLifetimeScope();

			builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
				.Where(t => t.Name.EndsWith("AuditDefinition"))
				.AsImplementedInterfaces().PropertiesAutowired();

			//Constants.EventQueues.Queue.ForEach(source =>
			//builder.RegisterType<RabbitMqManager>()
			//	.As<IEventManager>()
			//	.Named(source, typeof(IEventManager))
			//	.WithParameter(new TypedParameter(typeof(string), source))
			//	.SingleInstance()/			//);

			builder
				.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
				.Where(t => t.Name.EndsWith("Handler") && t.FullName.Contains("KudoCode.")
				&& !t.FullName.Contains("GetApplicationUserDtoWorkerHandler") // register from cache above
				// && !t.FullName.Contains("KudoCode.Contracts.Domain")
				)
				.AsImplementedInterfaces().PropertiesAutowired();

	//		builder.RegisterGeneric(typeof(GetApplicationUserContextAuthenticationHandler<,>))
	//.AsImplementedInterfaces()
	//.InstancePerLifetimeScope();
		}
	}
}
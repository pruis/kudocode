using System;
using System.Collections.Generic;
using Autofac;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using KudoCode.LogicLayer.Infrastructure.Execution.Context;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Participants;
using KudoCode.LogicLayer.Infrastructure.Execution.PipeLines;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using KudoCode.LogicLayer.Infrastructure.Token;
using log4net;

namespace KudoCode.LogicLayer.Infrastructure
{
    public class AutofacInfrastructure : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(AuthenticationHandler<,>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EventRequestDto<>))
                .As(typeof(IEventRequestDto<>)).InstancePerDependency();

            builder.RegisterGeneric(typeof(FluentValidationHandler<,>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(AuthenticationSecondaryFilter<,>));
            builder.RegisterGeneric(typeof(AuthenticationFilter<,>));
            builder.RegisterGeneric(typeof(AuthorizationFilter<,>));
            builder.RegisterGeneric(typeof(FluentValidationFilter<,>));
            builder.RegisterGeneric(typeof(CustomValidationParticipant<,>));
            builder.RegisterGeneric(typeof(WorkerFilter<,>));
            builder.RegisterGeneric(typeof(EventFilter<,>));
            builder.RegisterGeneric(typeof(AggregateFilter<,>));

            builder.RegisterGeneric(typeof(ExecutionPipelineContext<>))
                .As(typeof(IExecutionPipelineContext<>))
                .As(typeof(IWorkerContext<>))
                .As(typeof(IValidationContext<>))
                .As(typeof(ICustomValidationContext<>))
                .As(typeof(IAuthorizationContext<>))
                .As(typeof(IAuthenticationContext<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<ApiControllerRequestManager>();

            builder.RegisterType<ApplicationUserContext>().As<IApplicationUserContext>()
               .InstancePerMatchingLifetimeScope("ExecutionPipeline")
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

            builder.Register(c => LogManager.GetLogger(typeof(Object))).As<ILog>();
            builder.RegisterGeneric(typeof(CommandHandlerDelegates<,,>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(QueryHandlerDelegates<,,>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(WorkerHandlerDelegates<,>)).InstancePerLifetimeScope();

            builder
                .RegisterType<ProxyTokenCache>()
                .As<ITokenCache>().InstancePerMatchingLifetimeScope("ExecutionPipeline");
        }
    }
}
using Autofac;
using Core.Services.Workflow.RabbitMQ.Infrastructure;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain;
using KudoCode.LogicLayer.Dtos;
using System;

namespace KudoCode.Web.Api
{
	public class AutoFacWebApi : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<GetTableAInterceptor>()
				.AsSelf()
				.AsImplementedInterfaces().Named<IDynamicInterceptor>("GetTableA");

			builder.RegisterType<SaveTableAInterceptor>()
				.AsSelf()
				.AsImplementedInterfaces().Named<IDynamicInterceptor>("SaveTableA");

			builder.RegisterType<ListTableAInterceptor>()
				.AsSelf()
				.AsImplementedInterfaces().Named<IDynamicInterceptor>("ListTableA");

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
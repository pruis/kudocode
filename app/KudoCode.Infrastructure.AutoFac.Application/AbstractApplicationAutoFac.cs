using System;
using System.Collections.Generic;
using Autofac;
using KudoCode.Abstract.Application;
using KudoCode.Contracts;

namespace KudoCode.Infrastructure.AutoFac.Application
{
	public class AbstractApplicationAutoFac : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterInstance(new ListILookup()).AsSelf().SingleInstance();
			builder.RegisterType<GetLookupRequestContext>().As<IGetLookupRequestContext>().InstancePerLifetimeScope();
		}
	}
}
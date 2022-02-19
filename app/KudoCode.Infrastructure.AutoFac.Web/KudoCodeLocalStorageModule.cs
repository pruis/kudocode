using Autofac;
using KudoCode.Contracts;
using KudoCode.Contracts.Web;
using System;
using System.Collections.Generic;

namespace KudoCode.Infrastructure.AutoFac.Web
{
	public class KudoCodeLocalStorageModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<KudoCodeLocalStorage>().As<IStorage>().SingleInstance();
			builder.RegisterType<CsrfLocalStorageTokenCache>().As<ITokenCache>().SingleInstance();
			builder.RegisterType<GetLookupResponse>().As<IGetLookupResponse>().SingleInstance();
		}
	}
}
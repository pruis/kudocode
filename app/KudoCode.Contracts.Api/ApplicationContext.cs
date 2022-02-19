using System;
using Autofac;

namespace KudoCode.Contracts.Api
{
	public static class ApplicationContext
	{
		public static IContainer Container { get; set; }

		//public static ILifetimeScope Scope;
		//[ThreadStatic]
	}
}
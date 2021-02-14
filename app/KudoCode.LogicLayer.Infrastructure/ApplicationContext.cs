using System;
using Autofac;

namespace KudoCode.LogicLayer.Infrastructure
{
	public static class ApplicationContext
	{
		public static IContainer Container { get; set; }

		//public static ILifetimeScope Scope;
		//[ThreadStatic]
	}
}
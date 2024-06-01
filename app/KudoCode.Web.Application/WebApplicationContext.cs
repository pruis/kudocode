using System;
using KudoCode.Contracts;
using KudoCode.Contracts;

namespace KudoCode.Web.Application
{
	public static class WebApplicationContext
    {
		[ThreadStatic]
		public static IApplicationUserContext ApplicationUserContext;

    }
}

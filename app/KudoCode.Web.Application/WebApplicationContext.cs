using System;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;

namespace KudoCode.Web.Application
{
	public static class WebApplicationContext
    {
		[ThreadStatic]
		public static IApplicationUserContext ApplicationUserContext;

    }
}

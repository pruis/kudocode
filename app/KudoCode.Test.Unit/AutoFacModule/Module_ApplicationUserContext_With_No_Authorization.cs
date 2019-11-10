using Autofac;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;

namespace KudoCode.Test.Unit.AutoFacModule
{
	public class Module_ApplicationUserContext_With_No_Authorization : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterInstance(new ApplicationUserContext()
			{
				ActiveEntityOrganizationId = 1,
				Id = 1,
				Email = "test@test.com",
				//AuthorizationRole = AuthorizationHandlerDtos.Get().Role,
				//AuthorizationGroups = AuthorizationHandlerDtos.Get().Groups
			}).As<IApplicationUserContext>().SingleInstance();
		}
	}
}

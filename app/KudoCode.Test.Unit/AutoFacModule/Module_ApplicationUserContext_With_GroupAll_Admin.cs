using System;
using Autofac;
using KudoCode.LogicLayer.Dtos.Authorization;
using KudoCode.Contracts;
using KudoCode.Contracts;
using KudoCode.Contracts;
using KudoCode.Contracts;

namespace KudoCode.Test.Unit.AutoFacModule
{
    public class Module_ApplicationUserContext_With_GroupAll_Admin : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new ApplicationUserContext()
            {
                ActiveEntityOrganizationId = 1,
                Id = 1,
                Email = "test@test.com",
                AuthorizationRole = AuthorizationHandlerDtos.Get.Role,
                AuthorizationGroups = AuthorizationHandlerDtos.Get.Groups,
                Token = new TokenDto() {Value = "TESTTOKEN", ValidTo = DateTime.Now.AddDays(2), IsValidTokenProvided = true}
            }).As<IApplicationUserContext>().SingleInstance();
        }
    }


}
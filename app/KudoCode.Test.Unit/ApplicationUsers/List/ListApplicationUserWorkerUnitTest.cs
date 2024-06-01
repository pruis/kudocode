using Autofac;
using KudoCode.Contracts;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;


namespace KudoCode.Test.Unit.ApplicationUsers.List
{
    [TestClass]
    public class ListApplicationUserWorkerUnitTest : UnitTestBase
    {
        private ListApplicationUserRequest _request;
        private IWorkerContext<ListApplicationUserResponse> _getResponse;

        public ListApplicationUserWorkerUnitTest()
        {
        }

        [TestMethod]
        public void ListApplicationUserRequestWorker()
        {
            base.Run(
                "ListApplicationUserRequest Worker",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            ApplicationContext
                .Container
                .Resolve<IHandler<SaveApplicationUserRequest, IValidationContext<ApplicationUserContext>>>()
                .Handle(new SaveApplicationUserRequest() { Email = $"{Guid.NewGuid()}@email.com", Name = "test", Surname = "test", Password = "1234", Repassword = "1234", ActiveEntityOrganizationId = 1 });

            _request = new ListApplicationUserRequest() { };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<ListApplicationUserRequest, IWorkerContext<ListApplicationUserResponse>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
               a.Type == MessageDtoType.Error));
        }
    }
}

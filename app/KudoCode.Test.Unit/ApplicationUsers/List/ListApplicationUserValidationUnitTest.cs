using Autofac;
using KudoCode.Contracts;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace KudoCode.Test.Unit.ApplicationUsers.List
{
    [TestClass]
    public class ListApplicationUserValidationUnitTest : UnitTestBase
    {
        private ListApplicationUserRequest _request;
        private IValidationContext<ListApplicationUserResponse> _getResponse;

        public ListApplicationUserValidationUnitTest()
        {
        }

        [TestMethod]
        public void ListApplicationUserRequestValidation()
        {
            base.Run(
                "ListApplicationUserRequest Validation",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            _request = new ListApplicationUserRequest() { };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<ListApplicationUserRequest, IValidationContext<ListApplicationUserResponse>>>()
                .Handle(_request);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
               a.Type == MessageDtoType.Error));
        }
    }
}

using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.ImportExcel;
using KudoCode.Contracts;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.Portfolios.CreatePortfolioImportXls
{
	[TestClass]
    public class CreatePortfolioImportXlsAuthorizationUnitTest : UnitTestBase
    {
        private CreateImportXlsDto _dto;
        private IAuthorizationContext<int> _getResponse;

        [TestMethod]
        public void CreateImportXlsDtoAuthorization()
        {
            base.Run(
                "CreateImportXlsDto Authorization",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
            ApplicationContext.Container.Resolve<IApplicationUserContext>().Token
                .IsValidTokenProvided = true;
        }

        protected override void Given()
        {
            _dto = new CreateImportXlsDto() { };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<CreateImportXlsDto, IAuthorizationContext<int>>>()
                .Handle(_dto);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));
        }
    }
}
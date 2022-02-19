using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.ImportExcel;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.Portfolios.CreatePortfolioImportXls
{
	[TestClass]
    public class CreatePortfolioImportXlsValidationUnitTest : UnitTestBase
    {
        private CreateImportXlsDto _dto;
        private IValidationContext<int> _getResponse;

        public CreatePortfolioImportXlsValidationUnitTest()
        {
        }

        [TestMethod]
        public void CreateImportXlsDtoValidation()
        {
            base.Run(
                "CreateImportXlsDto Validation",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            _dto = new CreateImportXlsDto() { };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<CreateImportXlsDto, IValidationContext<int>>>()
                .Handle(_dto);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));
        }
    }
}
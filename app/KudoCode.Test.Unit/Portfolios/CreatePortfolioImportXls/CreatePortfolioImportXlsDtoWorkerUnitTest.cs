using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.ImportExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace KudoCode.Test.Unit.Portfolios.CreatePortfolioImportXls
{
	//[TestClass()]
	public class CreatePortfolioImportXlsWorkerUnitTest : UnitTestBase
    {
        private CreateImportXlsDto _dto;
        private IWorkerContext<ImportXlsPipelineResponse> _getResponse;

        [TestMethod]
        public void CreateImportXlsDtoWorker()
        {
            base.Run(
                "CreateImportXlsDto Worker",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            _dto = new CreateImportXlsDto()
            {
                FilePath = @"C:\Projects\Imports\Y Birdy.xls",
                //FilePath = @"C:\Projects\Imports\Portfolios\Y 1.xls",
                Sheets = new List<string>() {"Report"}
            };
        }

        protected override void When()
        {
            _getResponse = ApplicationContext
                .Container
                .Resolve<IHandler<CreateImportXlsDto, IWorkerContext<ImportXlsPipelineResponse>>>()
                .Handle(_dto);
        }

        protected override void Then()
        {
            Assert.IsFalse(_getResponse.HasErrors());
        }
    }
}
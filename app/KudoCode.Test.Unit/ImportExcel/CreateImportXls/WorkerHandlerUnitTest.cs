using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.ImportExcel;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.ImportExcel.CreateImportXls
{
    [TestClass]
    public class WorkerHandlerUnitTest : UnitTestBase
    {
        private CreateImportXlsDto _dto;
        private IWorkerContext<ImportXlsPipelineResponse> _saveResponse;

        public WorkerHandlerUnitTest()
        {
        }

        [TestMethod]
        public void ImportPortfolio()
        {
            base.Run(
                "CreateImportXlsDto WorkerHandler",
                "Given a CreateImportXlsDto",
                "when I call CreateImportXlsDtoWorkerHandler",
                "Then I receive an ID with no error messages");
        }

        protected override void Seed()
        {
            SeedDataBase.InitializeDataBase();
        }

        protected override void Given()
        {
            _dto = new CreateImportXlsDto()
            {
                FilePath = @"Files\Y Birdy.xls",
                Sheets = new List<string>() {"Report"}
            };
        }

        protected override void When()
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope(ScopeKey))
            {
                //File to Stg
                _saveResponse = scope
                    .Resolve<IHandler<CreateImportXlsDto, IWorkerContext<ImportXlsPipelineResponse>>>()
                    .Handle(_dto);
            }
        }

        protected override void Then()
        {
            Assert.IsTrue(_saveResponse.Result.ImportXlsId > 0);
            Assert.IsTrue(!_saveResponse.HasErrors());
        }
    }
}
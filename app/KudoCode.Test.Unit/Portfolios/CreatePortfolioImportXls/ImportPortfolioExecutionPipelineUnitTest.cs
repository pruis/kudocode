using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Domain.Logic.Portfolios.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsConsolidations.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Entities;
using KudoCode.LogicLayer.Dtos.ImportExcel;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.Test.Unit.Portfolios.CreatePortfolioImportXls
{
	//[TestClass]
	public class ImportPortfolioWorkerHandlerUnitTest : UnitTestBase
    {
        private CreateImportXlsDto _dto;
        private IApiResponseContextDto<ImportXlsPipelineResponse> _saveResponse;
        private Portfolio _portfolio;
        private PortfolioTransactionsSummary _portfolioTransactionsSummary;
        private IEnumerable<PortfolioTransactionsConsolidation> _portfolioTransactionsConsolidation;

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
            ApplicationContext.Container.Resolve<IApplicationUserContext>().Token.IsValidTokenProvided = true;
        }

        protected override void Given()
        {
            _dto = new CreateImportXlsDto()
            {
                FilePath = @"C:\Projects\Imports\Portfolios\Y Exponential.xls",
                //FilePath = @"C:\Projects\Imports\Y Birdy.xls",
                Sheets = new List<string>() {"Report"}
            };
        }

        protected override void When()
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope(ScopeKey))
            {
                _saveResponse = scope.ResolveKeyed<IExecutionPipelineHandlers>("ImportProfile")
                    .Execute<CreateImportXlsDto, ImportXlsPipelineResponse>(_dto);

                _portfolio = scope.Resolve<IRepository>()
                    .GetOne<Portfolio>(a => a.Id == _saveResponse.Result.PortfolioId);

                _portfolioTransactionsSummary = scope.Resolve<IRepository>()
                    .GetOne<PortfolioTransactionsSummary>(a =>
                        a.Id == _saveResponse.Result.PortfolioTransactionsSummaryId);

                var x = scope.Resolve<IRepository>()
                    .GetAll<PortfolioTransactionsConsolidation>();

                _portfolioTransactionsConsolidation = scope.Resolve<IRepository>()
                    .Get<PortfolioTransactionsConsolidation>(a =>
                        a.PortfolioTransactionsSummaryId == _saveResponse.Result.PortfolioTransactionsSummaryId);
            }
        }

        protected override void Then()
        {
            Assert.IsTrue(_saveResponse.Result.ImportXlsId > 0);
            Assert.IsTrue(_saveResponse.Result.PortfolioId > 0);
            Assert.IsTrue(_saveResponse.Result.PortfolioTransactionsSummaryId > 0);
            Assert.IsTrue(!_saveResponse.HasErrors());

            Assert.IsTrue(!string.IsNullOrWhiteSpace(_portfolio.Name));

            Assert.IsTrue(_portfolioTransactionsSummary != null);
            Assert.IsTrue(_portfolioTransactionsSummary.CloseAmount > 0);
            Assert.IsTrue(_portfolioTransactionsSummary.OpenAmount > 0);

            Assert.IsTrue(_portfolioTransactionsConsolidation != null);
            Assert.IsTrue(_portfolioTransactionsConsolidation.Any());
        }
    }
}
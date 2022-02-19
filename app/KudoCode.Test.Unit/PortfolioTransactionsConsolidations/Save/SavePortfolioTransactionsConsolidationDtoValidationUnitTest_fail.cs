using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Inbound;
using KudoCode.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.PortfolioTransactionsConsolidations.Save
{
	[TestClass]
	public class SavePortfolioTransactionsConsolidationValidationUnitTest : UnitTestBase
	{
		private SavePortfolioTransactionsConsolidationDto _dto;
		private IValidationContext<int> _getResponse ;

		[TestMethod]
		public void SavePortfolioTransactionsConsolidationDtoValidation()
		{
			base.Run(
				"SavePortfolioTransactionsConsolidationDto Validation",
				"",
				"",
				"");
		}

		protected override void Seed()
		{

		}

		protected override void Given()
		{
			_dto = new SavePortfolioTransactionsConsolidationDto() { };
		}

		protected override void When()
		{
			_getResponse  = ApplicationContext
				.Container
				.Resolve<IHandler<SavePortfolioTransactionsConsolidationDto, IValidationContext<int>>>()
				.Handle(_dto);
		}

		protected override void Then()
		{
			Assert.IsTrue(_getResponse .Messages.Any(a =>
				a.Type == MessageDtoType.Error));

			Assert.IsTrue(_getResponse .Messages.Any(a =>
				a.Key.Equals("E6") && a.Message.Contains("Portfolio Transactions Summary Id")));
		}
	}
}

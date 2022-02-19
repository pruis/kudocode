using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.Companys.Entities;
using KudoCode.LogicLayer.Dtos.Comanys.Outbound;
using KudoCode.Contracts;
using KudoCode.Test.Unit;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Core.Test.Unit.Comanys.List
{
	[TestClass]
	public class ListComanyWorkerUnitTest : UnitTestBase
	{
		private ListCompanyRequest _request;
		private IWorkerContext<ListCompanyResponse> _getResponse;

		public ListComanyWorkerUnitTest()
		{
		}

		[TestMethod]
		public void ListComanyRequestWorker()
		{
			base.Run(
				"ListComanyRequest Worker",
				"",
				"",
				"");
		}

		protected override void Seed()
		{
			using var scope = ApplicationContext.Container.BeginLifetimeScope();
			using var dbSet = scope.Resolve<InMemoryDataContextUnitTest>();
			dbSet.Set<Company>();
			dbSet.Add(new Company());
			dbSet.Add(new Company());
			dbSet.Add(new Company());
			dbSet.SaveChanges();
		}

		protected override void Given()
		{
			_request = new ListCompanyRequest() { };
		}

		protected override void When()
		{
			_getResponse = ApplicationContext
				.Container
				.Resolve<IHandler<ListCompanyRequest, IWorkerContext<ListCompanyResponse>>>()
				.Handle(_request);
		}

		protected override void Then()
		{
			Assert.IsTrue(_getResponse.Result.List.Count == 3);
			Assert.IsFalse(_getResponse.Messages.Any(a =>
			   a.Type == MessageDtoType.Error));
		}
	}
}

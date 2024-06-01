using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.Companys.Entities;
using KudoCode.LogicLayer.Dtos.Comanys.Outbound;
using KudoCode.Contracts;
using KudoCode.Test.Unit;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Core.Test.Unit.Comanys.Get
{
	[TestClass]
	public class GetCompanyWorkerUnitTest : UnitTestBase
	{
		private GetCompanyRequest _request;
		private IWorkerContext<GetCompanyResponse> _getResponse;

		public GetCompanyWorkerUnitTest()
		{
		}

		[TestMethod]
		public void GetComanyRequestWorker()
		{
			base.Run(
				"GetComanyRequest Worker",
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



		}

		protected override void Given()
		{
			_request = new GetCompanyRequest() { };
		}

		protected override void When()
		{
			_getResponse = ApplicationContext
				.Container
				.Resolve<IHandler<GetCompanyRequest, IWorkerContext<GetCompanyResponse>>>()
				.Handle(_request);
		}

		protected override void Then()
		{
			Assert.IsFalse(_getResponse.Messages.Any(a =>
			   a.Type == MessageDtoType.Error));
		}
	}
}

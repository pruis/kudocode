using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.Companys.Entities;
using KudoCode.LogicLayer.Dtos.Companys.Outbound;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Contracts;
using KudoCode.Test.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Core.Test.Unit.Companys.Delete
{
	[TestClass]
	public class DeleteCompanyWorkerUnitTest : UnitTestBase
	{
		private DeleteCompanyRequest _request;
		private IWorkerContext<DeleteCompanyResponse> _getResponse;
		private int _id;

		public DeleteCompanyWorkerUnitTest()
		{
		}

		[TestMethod]
		public void DeleteCompanyRequestWorker()
		{
			base.Run(
				"DeleteCompanyRequest Worker",
				"",
				"",
				"");
		}

		protected override void Seed()
		{
			var dbset = DataContext.Set<Company>();
			var c = new Company() { };
			dbset.Add(c);
			DataContext.SaveChanges();
			_id = c.Id;
		}

		protected override void Given()
		{
			_request = new DeleteCompanyRequest() { Id = _id };

		}

		protected override void When()
		{
			_getResponse = ApplicationContext
				.Container
				.Resolve<IHandler<DeleteCompanyRequest, IWorkerContext<DeleteCompanyResponse>>>()
				.Handle(_request);
		}

		protected override void Then()
		{
			Assert.IsFalse(_getResponse.Messages.Any(a =>
			   a.Type == MessageDtoType.Error));
		}
	}
}

using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KudoCode.Test.Unit.Leads.GetLead
{
	[TestClass]
	public class GetLeadWorkerHandlerUnitTest : UnitTestBase
	{
		private int _leadId;
		private GetLeadRequest _getLeadRequest;
		private IApplicationUserContext _appUser;
		private IWorkerContext<GetLeadResponse> _getResponse;

		[TestMethod]
		public void GetLead()
		{
			base.Run(
				"GetLeadDto WorkerHandler",
				"Given a lead id",
				"When I call the GetLeadDtoWorkerHandler with GetLeadDto",
				"Then i receive a result with no error messages");
		}

		protected override void Seed()
		{
			SeedDataBase.InitializeDataBase();
			_leadId = SeedDataBase.CreateLead($"test{TestHelpers.UniqueName()}B@testC.com");
		}

		protected override void Given()
		{
			_getLeadRequest = new GetLeadRequest() { Id = _leadId };
			_appUser = ApplicationContext.Container.Resolve<IApplicationUserContext>();
		}

		protected override void When()
		{
			using (var scope = ApplicationContext.Container.BeginLifetimeScope(ScopeKey))
			{
				_getResponse = scope
					.Resolve<IHandler<GetLeadRequest, IWorkerContext<GetLeadResponse>>>()
					.Handle(_getLeadRequest);
			}
		}

		protected override void Then()
		{


			Assert.IsTrue(
				_getResponse.Result.Agent != null);

			Assert.IsTrue(
			_getResponse.Result.LeadPersonalInformation.FirstName.Equals("test"));

			Assert.IsFalse(
				_getResponse.Messages.Any(a => a.Type == MessageDtoType.Error));
			Assert.IsTrue(_getResponse.Result.ApplicationUserEmail.Equals(_appUser.Email),
				"result application user email != request application user email");

			Assert.IsNotNull((_getResponse.Aggregates[0] as EventRequestDto<ApiControllerRequestDto>)
				.MetaData);
		}
	}
}
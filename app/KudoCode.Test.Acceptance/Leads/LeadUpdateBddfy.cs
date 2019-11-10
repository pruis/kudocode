using System.Linq;
using KudoCode.Web.Api.Connector;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace KudoCode.Test.Acceptance.Leads
{
	public class LeadUpdateBddfy
	{
		private Connector _connector;
		private IApiResponseContextDto<int> _responseDto;
		private UpdateLeadRequest _request;
		private string _firstName = "test";
		private string _firstName_updated = "TestLeadUpdateX";
		private string _email = TestHelpers.UniqueName() + "@gmail.com";

		public void Update(Connector connector)
		{
			_connector = connector;
			this.Given(_ => GivenAnExistingLead())
				.When(_ => WhenIUpdateTheLead())
				.Then(_ => ThenTheResponseOnFetchIsSuccessful())
				.BDDfy();
		}

		public void GivenAnExistingLead()
		{
			var newId = new LeadCreateBddfy().Params(_firstName,_email).Create(_connector);
			var leadResult = _connector.Lead.GetSingle(new GetLeadRequest { Id = newId });

			_request = new UpdateLeadRequest();
			_request.Id = newId;
			_request.LeadPersonalInformation = leadResult.Result.LeadPersonalInformation;
			_request.LeadPersonalInformationId = leadResult.Result.LeadPersonalInformationId;

			Assert.IsTrue(_request.Id > 0);
		}

		public void WhenIUpdateTheLead()
		{
			_request.LeadPersonalInformation.FirstName = _firstName_updated;
			_request.LeadPersonalInformation.Age = 25;
			_responseDto = _connector.Lead.Update(_request);

			Assert.IsFalse(_responseDto.HasErrors());
		}

		public void ThenTheResponseOnFetchIsSuccessful()
		{
			var testResposne = _connector.Lead.GetSingle(new GetLeadRequest() { Id = _responseDto.Result });
			Assert.IsTrue(testResposne.Result.LeadPersonalInformation.FirstName.Equals(_firstName_updated));
			Assert.IsTrue(testResposne.Result.Name.Equals($"{_firstName_updated} {_request.LeadPersonalInformation.Surname}"));
			Assert.IsTrue(testResposne.Result.Email.Equals(testResposne.Result.LeadPersonalInformation.Email));
			Assert.IsTrue(testResposne.Result.Agent != null);
			Assert.IsTrue(testResposne.Result.Id == _request.Id);

			var compare = _request.CompareProperties(testResposne.Result.LeadPersonalInformation,"Id");
			Assert.IsNull(compare,compare);
		}

	}
}
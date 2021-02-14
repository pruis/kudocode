using System;
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
	public class LeadCreateBddfy
	{
		private Connector _connector;
		private IApiResponseContextDto<int> _responseDto;
		private CreateLeadRequest _request;
		private readonly string _surname = DateTime.Now.ToLongTimeString();
		private string _firstName = "test";
		private string _email = TestHelpers.UniqueName() + "@gmail.com";
		private DateTime _appointmentDate;
		private string _appointmentDateString;

		public int Create(Connector connector)
		{
			_connector = connector;
			this.Given(_ => GivenANewLead())
				.When(_ => WhenICreateTheNewLead())
				.Then(_ => ThenTheResponseOnFetchIsSuccessful())
				.BDDfy();

			return _responseDto.Result;
		}

		public void GivenANewLead()
		{

			_appointmentDateString = DateTime.Now.AddDays(2).ToString("dd-MM-yyyy HH:mm");
			_appointmentDate = DateTime.Now.AddDays(2);

			_request = new CreateLeadRequest()
			{
				LeadPersonalInformation = new LeadPersonalInformationDto()
				{
					FirstName = _firstName,
					Surname = _surname,
					Email = _email,
					CurrentAdvisorId = 1,
					GenderId = 1,
					OccupationId = 1
				},
			};
		}

		public void WhenICreateTheNewLead()
		{
			_responseDto = _connector.Lead.Create(_request);
			Assert.IsFalse(_responseDto.HasErrors());
		}

		public void ThenTheResponseOnFetchIsSuccessful()
		{
			var testResposne = _connector.Lead.GetSingle(new GetLeadRequest() { Id = _responseDto.Result });
			Assert.IsTrue(testResposne.Result.LeadPersonalInformation.FirstName.Equals(_firstName));
			Assert.IsTrue(testResposne.Result.LeadPersonalInformation.Surname.Equals(_surname));
			Assert.IsTrue(testResposne.Result.Name.Equals($"{_firstName} {_surname}"));
			Assert.IsTrue(testResposne.Result.Email.Equals(testResposne.Result.LeadPersonalInformation.Email));
			Assert.IsTrue(testResposne.Result.Agent != null);
			Assert.IsTrue(testResposne.Result.Id > 0);

			var compare = _request.CompareProperties(testResposne.Result.LeadPersonalInformation, "Id");
			Assert.IsNull(compare, compare);

		}

		public LeadCreateBddfy Params(string firstName, string email)
		{
			_firstName = firstName;
			_email = email;
			return this;
		}
	}
}

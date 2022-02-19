using KudoCode.Contracts;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.Web.Api.Connector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TestStack.BDDfy;

namespace KudoCode.Test.Acceptance.Leads
{
	public class LeadScheduledActivityCreateBddfy
    {
        private Connector _connector;
        private IApiResponseContextDto<int> _responseDto;
        private int _leadId;
        private string _firstName = "test";
        private string _email = TestHelpers.UniqueName() + "@gmail.com";
        private CreateGetLeadScheduledActivityRequest _request;
        private string _appointmentDateString;

        public CreateGetLeadScheduledActivityRequest Create(Connector connector)
        {
            _connector = connector;
            this.Given(_ => GivenAnExistingLead())
                .When(_ => WhenICreateANewLeadScheduledActivity())
                .Then(_ => ThenTheResponseIsSuccessful())
                .BDDfy();

            return _request;
        }

        public void GivenAnExistingLead()
        {
            _leadId = new LeadCreateBddfy().Params(_firstName, _email).Create(_connector);
            Assert.IsTrue(_leadId > 0);
        }

        public void WhenICreateANewLeadScheduledActivity()
        {
            _appointmentDateString = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd HH:mm:ss");
            _request = new CreateGetLeadScheduledActivityRequest()
            {
                LeadScheduledActivityTypeId = 2,
                LeadId = _leadId,
                AppointmentDateTime = _appointmentDateString,
                Address = new AddressDto()
                {
                    City = "City",
                    Code = "Code",
                    Complex = "Complex",
                    Street = "street",
                    Suburb = "Suburb",
                    AddressTypeId = 1
                }
            };

            _responseDto = _connector.LeadScheduledActivity.Create(_request);
            Assert.IsFalse(_responseDto.HasErrors());
            Assert.IsTrue(_responseDto.Result > 0);
        }

        public void ThenTheResponseIsSuccessful()
        {
            var testResposne =
                _connector.LeadScheduledActivity.Get(
                    new GetLeadScheduledActivityRequest() {Id = _responseDto.Result, LeadId = _leadId});

            Assert.IsFalse(testResposne.HasErrors());

            var getLeadResponseDto = _connector.Lead.GetSingle(new GetLeadRequest() {Id = _leadId});

            Assert.IsTrue(getLeadResponseDto.Result.LeadScheduledActivities.Any());

            Assert.IsTrue(testResposne.Result.AppointmentDateTime.Equals(_appointmentDateString));
            Assert.IsTrue(testResposne.Result.Address != null);
            Assert.IsTrue(testResposne.Result.Address.Id > 0);
            Assert.IsTrue(testResposne.Result.Id == _request.Id);
            Assert.IsTrue(testResposne.Result.LeadScheduledActivityTypeId == 2);

            var compare = _request.CompareProperties(testResposne.Result, "Id,AddressId");
            Assert.IsNull(compare, compare);

            var compareAddress = _request.Address.CompareProperties(testResposne.Result.Address, "Id");
            Assert.IsNull(compareAddress, compareAddress);
        }
    }
}
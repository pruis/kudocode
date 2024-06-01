using KudoCode.Contracts;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.Web.Api.Connector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using TestStack.BDDfy;
namespace KudoCode.Test.Acceptance.Leads
{
	public class LeadScheduledActivityUpdateBddfy
    {
        private Connector _connector;
        private string _email = TestHelpers.UniqueName() + "@gmail.com";
        private string _appointmentDateString;
        private IApiResponseContextDto<int> _updateResponseDto;

        private CreateGetLeadScheduledActivityRequest CreateGetLeadScheduledActivityRequest { get; set; }

        public void Update(Connector connector)
        {
            _connector = connector;
            this.Given(_ => GivenAnExistingLeadWithAnScheduledActivity())
                .When(_ => WhenIUpdateLeadScheduledActivity())
                .Then(_ => ThenTheResponseIsSuccessful())
                .BDDfy();
        }

        public void GivenAnExistingLeadWithAnScheduledActivity()
        {
            CreateGetLeadScheduledActivityRequest = new LeadScheduledActivityCreateBddfy().Create(_connector);
            Assert.IsTrue(CreateGetLeadScheduledActivityRequest.Id > 0);
            Assert.IsTrue(CreateGetLeadScheduledActivityRequest.LeadId > 0);
        }

        public void WhenIUpdateLeadScheduledActivity()
        {
            var getResult = _connector.LeadScheduledActivity.Get(new GetLeadScheduledActivityRequest()
                {Id = CreateGetLeadScheduledActivityRequest.Id, LeadId = CreateGetLeadScheduledActivityRequest.LeadId});

            var serializedParent = JsonConvert.SerializeObject(getResult.Result);
            var updateLeadScheduledActivityDto =
                JsonConvert.DeserializeObject<UpdateGetLeadScheduledActivityRequest>(serializedParent);

            _appointmentDateString = DateTime.Now.AddDays(5).ToString("yyyy-MM-dd HH:mm:ss");
            updateLeadScheduledActivityDto.AppointmentDateTime = _appointmentDateString;
            _updateResponseDto = _connector.LeadScheduledActivity.Upate(updateLeadScheduledActivityDto);
        }

        public void ThenTheResponseIsSuccessful()
        {
            Assert.IsFalse(_updateResponseDto.HasErrors());
            Assert.IsTrue(_updateResponseDto.Result > 0);

            var testResposne =
                _connector.LeadScheduledActivity.Get(
                    new GetLeadScheduledActivityRequest()
                        {Id = _updateResponseDto.Result, LeadId = CreateGetLeadScheduledActivityRequest.LeadId});
            Assert.IsFalse(testResposne.HasErrors());
            Assert.IsTrue(testResposne.Result.AppointmentDateTime.Equals(_appointmentDateString));
            Assert.IsTrue(testResposne.Result.Address != null);
            Assert.IsTrue(testResposne.Result.Address.Id > 0);
        }
    }
}
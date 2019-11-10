using System;
using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.LogicLayer.Dtos.Lookups;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.Leads
{
    public class UpdateGetLeadScheduledActivityRequest : ILeadScheduledActivityDto,IApiRequestDto
    {
        public UpdateGetLeadScheduledActivityRequest()
        {
            AppointmentDateTime = DateTime.Now.ToString();
        }

        public int Id { get; set; }
        public string AppointmentDateTime { get; set; }

        public string Notes { get; set; }

        public int? AddressId { get; set; }
        public AddressDto Address { get; set; }

        public List<AddressTypeDto> AddressTypes { get; set; }

        public int LeadId { get; set; }

        public int LeadScheduledActivityTypeId { get; set; }
        public LeadScheduledActivityTypeDto LeadScheduledActivityType { get; set; }
    }
}